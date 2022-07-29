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
using WarehouseManger.Application.Features.Patients.Commands.AddEdit;
using WarehouseManger.Application.Features.Patients.Queries.GetAllPaged;
using WarehouseManger.Application.Requests.Clinic;
using WarehouseManger.Client.Extensions;
using WarehouseManger.Client.Infrastructure.Managers.Clinic;
using WarehouseManger.Shared.Constants.Application;
using WarehouseManger.Shared.Constants.Permission;

namespace WarehouseManger.Client.Pages.Clinic
{
    

    public partial class Patient
    {
        [Inject] private IPatientManager PatientManager { get; set; }

        [CascadingParameter] private HubConnection HubConnection { get; set; }

        private IEnumerable<GetAllPagedPatientsResponse> _pagedData;
        private MudTable<GetAllPagedPatientsResponse> _table;
        private int _totalItems;
        private int _currentPage;
        private string _searchString = "";
        private bool _dense = false;
        private bool _striped = true;
        private bool _bordered = false;

        private ClaimsPrincipal _currentUser;
        private bool _canCreatePatients;
        private bool _canEditPatients;
        private bool _canDeletePatients;
        private bool _canExportPatients;
        private bool _canSearchPatients;
        private bool _loaded;

        protected override async Task OnInitializedAsync()
        {
            _currentUser = await _authenticationManager.CurrentUser();
            _canCreatePatients = (await _authorizationService.AuthorizeAsync(_currentUser, Permissions.Patient.Create)).Succeeded;
            _canEditPatients = (await _authorizationService.AuthorizeAsync(_currentUser, Permissions.Patient.Edit)).Succeeded;
            _canDeletePatients = (await _authorizationService.AuthorizeAsync(_currentUser, Permissions.Patient.Delete)).Succeeded;
            _canExportPatients = (await _authorizationService.AuthorizeAsync(_currentUser, Permissions.Patient.Export)).Succeeded;
            _canSearchPatients = (await _authorizationService.AuthorizeAsync(_currentUser, Permissions.Patient.Search)).Succeeded;

            _loaded = true;
            HubConnection = HubConnection.TryInitialize(_navigationManager);
            if (HubConnection.State == HubConnectionState.Disconnected)
            {
                await HubConnection.StartAsync();
            }
        }

        private async Task<TableData<GetAllPagedPatientsResponse>> ServerReload(TableState state)
        {
            if (!string.IsNullOrWhiteSpace(_searchString))
            {
                state.Page = 0;
            }
            await LoadData(state.Page, state.PageSize, state);
            return new TableData<GetAllPagedPatientsResponse> { TotalItems = _totalItems, Items = _pagedData };
        }

        private async Task LoadData(int pageNumber, int pageSize, TableState state)
        {
            string[] orderings = null;
            if (!string.IsNullOrEmpty(state.SortLabel))
            {
                orderings = state.SortDirection != SortDirection.None ? new[] { $"{state.SortLabel} {state.SortDirection}" } : new[] { $"{state.SortLabel}" };
            }

            var request = new GetAllPagedPatientsRequest { PageSize = pageSize, PageNumber = pageNumber + 1, SearchString = _searchString, Orderby = orderings };
            var response = await PatientManager.GetPatientsAsync(request);
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
            var response = await PatientManager.ExportToExcelAsync(_searchString);
            if (response.Succeeded)
            {
                await _jsRuntime.InvokeVoidAsync("Download", new
                {
                    ByteArray = response.Data,
                    FileName = $"{nameof(Patient).ToLower()}_{DateTime.Now:ddMMyyyyHHmmss}.xlsx",
                    MimeType = ApplicationConstants.MimeTypes.OpenXml
                });
                _snackBar.Add(string.IsNullOrWhiteSpace(_searchString)
                    ? "Patients exported"
                    : "Filtered Patients exported", Severity.Success);
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
                var patient = _pagedData.FirstOrDefault(c => c.Id == id);
                if (patient != null)
                {
                    parameters.Add(nameof(AddEditPatientModal.AddEditPatientModel), new AddEditPatientCommand
                    {
                        Id = patient.Id,
                        Address = patient.Address,
                        DateOfBirth =   patient.DateOfBirth,
                        EmailAddress = patient.EmailAddress,
                        FirstName = patient.FirstName,  
                        LastName = patient.LastName,    
                        Gender = patient.Gender,
                        OPDId = patient.OPDId,
                        PhoneNumber = patient.PhoneNumber
                        
                    });
                }
            }
            var options = new DialogOptions { CloseButton = true, MaxWidth = MaxWidth.Medium, FullWidth = true, DisableBackdropClick = true };
            var dialog = _dialogService.Show<AddEditPatientModal>(id == 0 ? "Create" : "Edit", parameters, options);
            var result = await dialog.Result;
            if (!result.Cancelled)
            {
                OnSearch("");
            }
        }

        private async Task Delete(int id)
        {
            string deleteContent = "Delete Patient";
            var parameters = new DialogParameters
            {
                {nameof(Shared.Dialogs.DeleteConfirmation.ContentText), string.Format(deleteContent, id)}
            };
            var options = new DialogOptions { CloseButton = true, MaxWidth = MaxWidth.Small, FullWidth = true, DisableBackdropClick = true };
            var dialog = _dialogService.Show<Shared.Dialogs.DeleteConfirmation>("Delete", parameters, options);
            var result = await dialog.Result;
            if (!result.Cancelled)
            {
                var response = await PatientManager.DeleteAsync(id);
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

        private void navigateToPatientVisit(int patientId)
        {
            _navigationManager.NavigateTo($"/clinic/PatientVisitDetails/{patientId}");
        }
    }
}
