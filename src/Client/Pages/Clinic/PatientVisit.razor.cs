using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.SignalR.Client;
using Microsoft.JSInterop;
using MudBlazor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using WarehouseManger.Application.Features.Patients.Queries.GetAllPaged;
using WarehouseManger.Application.Features.Patients.Queries.GetById;
using WarehouseManger.Application.Features.PatientVisits.Commands.AddEdit;
using WarehouseManger.Application.Features.PatientVisits.Queries.GetAllPaged;
using WarehouseManger.Application.Requests.Clinic;
using WarehouseManger.Client.Extensions;
using WarehouseManger.Client.Infrastructure.Managers.Clinic;
using WarehouseManger.Shared.Constants.Application;
using WarehouseManger.Shared.Constants.Permission;

namespace WarehouseManger.Client.Pages.Clinic
{
    
    public partial class PatientVisit
    {
        [Inject] private IPatientVisitManager PatientVisitManager { get; set; }
        [Inject] private IPatientManager PatientManager { get; set; }

        [CascadingParameter] private HubConnection HubConnection { get; set; }
        [Parameter]
        public string? patientId { get; set; }
        private IEnumerable<GetAllPagedPatientVisitsResponse> _pagedData;
        private MudTable<GetAllPagedPatientVisitsResponse> _table;
        private int _totalItems;
        private int _currentPage;
        private string _searchString = "";
        private bool _dense = false;
        private bool _striped = true;
        private bool _bordered = false;

        private ClaimsPrincipal _currentUser;
        private bool _canCreatePatientVisits;
        private bool _canEditPatientVisits;
        private bool _canDeletePatientVisits;
        private bool _canExportPatientVisits;
        private bool _canSearchPatientVisits;
        private bool _loaded;
        private GetPatientsByIdResponse patientDetail ;

        protected override async Task OnInitializedAsync()
        {
            _currentUser = await _authenticationManager.CurrentUser();
            _canCreatePatientVisits = (await _authorizationService.AuthorizeAsync(_currentUser, Permissions.PatientVisit.Create)).Succeeded;
            _canEditPatientVisits = (await _authorizationService.AuthorizeAsync(_currentUser, Permissions.PatientVisit.Edit)).Succeeded;
            _canDeletePatientVisits = (await _authorizationService.AuthorizeAsync(_currentUser, Permissions.PatientVisit.Delete)).Succeeded;
            _canExportPatientVisits = (await _authorizationService.AuthorizeAsync(_currentUser, Permissions.PatientVisit.Export)).Succeeded;
            _canSearchPatientVisits = (await _authorizationService.AuthorizeAsync(_currentUser, Permissions.PatientVisit.Search)).Succeeded;

            _loaded = true;
            await GetPatientDetails(int.Parse(patientId) );

            HubConnection = HubConnection.TryInitialize(_navigationManager);
            if (HubConnection.State == HubConnectionState.Disconnected)
            {
                await HubConnection.StartAsync();
            }
        }

        private async Task<TableData<GetAllPagedPatientVisitsResponse>> ServerReload(TableState state)
        {
            if (!string.IsNullOrWhiteSpace(_searchString))
            {
                state.Page = 0;
            }
            if(int.TryParse(patientId, out int patient))
            {
                await LoadData(state.Page, state.PageSize, state, patient);
                
                return new TableData<GetAllPagedPatientVisitsResponse> { TotalItems = _totalItems, Items = _pagedData };

               
            }


            return null; 
        }

        private async Task LoadData(int pageNumber, int pageSize, TableState state, int patientId)
        {
            string[] orderings = null;
            if (!string.IsNullOrEmpty(state.SortLabel))
            {
                orderings = state.SortDirection != SortDirection.None ? new[] { $"{state.SortLabel} {state.SortDirection}" } : new[] { $"{state.SortLabel}" };
            }

            var request = new GetAllPagedPatientVisitRequest { PageSize = pageSize, PageNumber = pageNumber + 1, SearchString = _searchString, Orderby = orderings, PatientId = patientId };
            var response = await PatientVisitManager.GetPatientVisitsAsync(request);
            if (response.Succeeded)
            {
                _totalItems = response.TotalCount;
                _currentPage = response.CurrentPage;
                _pagedData = response.Data;
            }
            else
            {
                foreach (var message in response.Messages)
                {
                    _snackBar.Add(message, Severity.Error);
                }
            }
        }

        private void OnSearch(string text)
        {
            _searchString = text;
            _table.ReloadServerData();
        }

        private async Task ExportToExcel()
        {
            int.TryParse(patientId, out int patient);
            var response = await PatientVisitManager.ExportToExcelAsync(patient, _searchString);
            if (response.Succeeded)
            {
                await _jsRuntime.InvokeVoidAsync("Download", new
                {
                    ByteArray = response.Data,
                    FileName = $"{nameof(PatientVisit).ToLower()}_{DateTime.Now:ddMMyyyyHHmmss}.xlsx",
                    MimeType = ApplicationConstants.MimeTypes.OpenXml
                });
                _snackBar.Add(string.IsNullOrWhiteSpace(_searchString)
                    ? "Patient Visit exported"
                    : "Filtered Patient Visit exported", Severity.Success);
            }
            else
            {
                foreach (var message in response.Messages)
                {
                    _snackBar.Add(message, Severity.Error);
                }
            }
        }

        private async Task InvokeModal(int id = 0)
        {
            var parameters = new DialogParameters();
            if (id != 0)
            {
                var patientVisit = _pagedData.FirstOrDefault(c => c.Id == id);
                if (patientVisit != null)
                {
                    parameters.Add(nameof(AddEditPatientVisitModal.AddEditPatientVisitModel), new AddEditPatientVisitCommand
                    {
                        Id = patientVisit.Id,
                        DateOfDischarge = patientVisit.DateOfDischarge,
                        DateOfVisit = patientVisit.DateOfVisit,
                        admission = patientVisit.admission,
                        Amount = patientVisit.Amount,
                        PatientVisitId = patientVisit.PatientVisitId,
                        Treatment = patientVisit.Treatment,
                        PatientDetailsId = patientVisit.PatientDetailsId,
                        DoctorDetailsId = patientVisit.DoctorDetailsId

                    });
                }
            }
            var options = new DialogOptions { CloseButton = true, MaxWidth = MaxWidth.Medium, FullWidth = true, DisableBackdropClick = true };
            var dialog = _dialogService.Show<AddEditPatientVisitModal>(id == 0 ? "Create" : "Edit", parameters, options);
            var result = await dialog.Result;
            if (!result.Cancelled)
            {
                OnSearch("");
            }
        }

        private async Task Delete(int id)
        {
            string deleteContent = "Delete Patient Visit";
            var parameters = new DialogParameters
            {
                {nameof(Shared.Dialogs.DeleteConfirmation.ContentText), string.Format(deleteContent, id)}
            };
            var options = new DialogOptions { CloseButton = true, MaxWidth = MaxWidth.Small, FullWidth = true, DisableBackdropClick = true };
            var dialog = _dialogService.Show<Shared.Dialogs.DeleteConfirmation>("Delete", parameters, options);
            var result = await dialog.Result;
            if (!result.Cancelled)
            {
                var response = await PatientVisitManager.DeleteAsync(id);
                if (response.Succeeded)
                {
                    OnSearch("");
                    await HubConnection.SendAsync(ApplicationConstants.SignalR.SendUpdateDashboard);
                    _snackBar.Add(response.Messages[0], Severity.Success);
                }
                else
                {
                    OnSearch("");
                    foreach (var message in response.Messages)
                    {
                        _snackBar.Add(message, Severity.Error);
                    }
                }
            }
        }


        private async Task GetPatientDetails(int patientId)
        {
            var response = await PatientManager.GetPatientById(patientId);
            if (response != null && response.Succeeded)
            {
                patientDetail = response.Data;
            }

           
        }
    }
}
