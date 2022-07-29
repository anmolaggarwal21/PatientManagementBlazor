using FluentValidation;
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
using WarehouseManger.Application.Features.Brands.Queries.GetAll;
using WarehouseManger.Application.Features.Doctors.Commands.AddEdit;
using WarehouseManger.Application.Features.Doctors.Queries.GetAll;
using WarehouseManger.Client.Extensions;
using WarehouseManger.Client.Infrastructure.Managers.Clinic;
using WarehouseManger.Shared.Constants.Application;
using WarehouseManger.Shared.Constants.Permission;

namespace WarehouseManger.Client.Pages.Clinic
{

    
    public partial class DoctorDetails 
    {
        [Inject] private IDoctorDetailsManager DoctorDetailsManager { get; set; }

        [CascadingParameter] private HubConnection HubConnection { get; set; }

        private List<GetAllDoctorDetailsResponse> _doctorList = new();
        private GetAllDoctorDetailsResponse _doctorDetail = new();
        private string _searchString = "";
        private bool _dense = false;
        private bool _striped = true;
        private bool _bordered = false;

        private ClaimsPrincipal _currentUser;
        private bool _canCreateDoctorDetails;
        private bool _canEditDoctorDetails;
        private bool _canDeleteDoctorDetails;
        private bool _canExportDoctorDetails;
        private bool _canSearchDoctorDetails;
        private bool _loaded;

        protected override async Task OnInitializedAsync()
        {
            _currentUser = await _authenticationManager.CurrentUser();
            _canCreateDoctorDetails = (await _authorizationService.AuthorizeAsync(_currentUser, Permissions.DoctorDetails.Create)).Succeeded;
            _canEditDoctorDetails = (await _authorizationService.AuthorizeAsync(_currentUser, Permissions.DoctorDetails.Edit)).Succeeded;
            _canDeleteDoctorDetails = (await _authorizationService.AuthorizeAsync(_currentUser, Permissions.DoctorDetails.Delete)).Succeeded;
            _canExportDoctorDetails = (await _authorizationService.AuthorizeAsync(_currentUser, Permissions.DoctorDetails.Export)).Succeeded;
            _canSearchDoctorDetails = (await _authorizationService.AuthorizeAsync(_currentUser, Permissions.DoctorDetails.Search)).Succeeded;

            await GetDoctorDetails();
            _loaded = true;
            HubConnection = HubConnection.TryInitialize(_navigationManager);
            if (HubConnection.State == HubConnectionState.Disconnected)
            {
                await HubConnection.StartAsync();
            }
        }

        private async Task GetDoctorDetails()
        {
            var response = await DoctorDetailsManager.GetAllAsync();
            if (response.Succeeded)
            {
                _doctorList = response.Data.ToList();
            }
            else
            {
                foreach (var message in response.Messages)
                {
                    _snackBar.Add(message, MudBlazor.Severity.Error);
                }
            }
        }

        private async Task Delete(int id)
        {
            string deleteContent = "Delete Doctor Details";
            var parameters = new DialogParameters
            {
                {nameof(Shared.Dialogs.DeleteConfirmation.ContentText), string.Format(deleteContent, id)}
            };
            var options = new DialogOptions { CloseButton = true, MaxWidth = MaxWidth.Small, FullWidth = true, DisableBackdropClick = true };
            var dialog = _dialogService.Show<Shared.Dialogs.DeleteConfirmation>("Delete", parameters, options);
            var result = await dialog.Result;
            if (!result.Cancelled)
            {
                var response = await DoctorDetailsManager.DeleteAsync(id);
                if (response.Succeeded)
                {
                    await Reset();
                    await HubConnection.SendAsync(ApplicationConstants.SignalR.SendUpdateDashboard);
                    _snackBar.Add(response.Messages[0], MudBlazor.Severity.Success);
                }
                else
                {
                    await Reset();
                    foreach (var message in response.Messages)
                    {
                        _snackBar.Add(message, MudBlazor.Severity.Error);
                    }
                }
            }
        }

        private async Task ExportToExcel()
        {
            var response = await DoctorDetailsManager.ExportToExcelAsync(_searchString);
            if (response.Succeeded)
            {
                await _jsRuntime.InvokeVoidAsync("Download", new
                {
                    ByteArray = response.Data,
                    FileName = $"{nameof(DoctorDetails).ToLower()}_{DateTime.Now:ddMMyyyyHHmmss}.xlsx",
                    MimeType = ApplicationConstants.MimeTypes.OpenXml
                });
                _snackBar.Add(string.IsNullOrWhiteSpace(_searchString)
                    ? "Doctor Details Exported"
                    : "Filtered Doctor Details exported", MudBlazor.Severity.Success);
            }
            else
            {
                foreach (var message in response.Messages)
                {
                    _snackBar.Add(message, MudBlazor.Severity.Error);
                }
            }
        }

        private async Task InvokeModal(int? id = 0)
        {
            var parameters = new DialogParameters();
            if (id != 0)
            {
                _doctorDetail = _doctorList.FirstOrDefault(c => c.Id == id);
                if (_doctorDetail != null)
                {
                    parameters.Add(nameof(AddOrEditDoctorDetailsModal.AddEditDoctorDetailsModel), new AddEditDoctorDetailsCommand
                    {
                        Id = _doctorDetail.Id,
                        DoctorName = _doctorDetail.DoctorName,
                        Department = _doctorDetail.Department,
                        DateOfBirth = _doctorDetail.DateOfBirth,
                        DoctorId = _doctorDetail.DoctorId
                    });
                }
            }
            var options = new DialogOptions { CloseButton = true, MaxWidth = MaxWidth.Small, FullWidth = true, DisableBackdropClick = true };
            var dialog = _dialogService.Show<AddOrEditDoctorDetailsModal>(id == 0 ? _localizer["Create"] : _localizer["Edit"], parameters, options);
            var result = await dialog.Result;
            if (!result.Cancelled)
            {
                await Reset();
            }
        }

        private async Task Reset()
        {
            _doctorDetail = new GetAllDoctorDetailsResponse();
            await GetDoctorDetails();
        }

        private bool Search(GetAllDoctorDetailsResponse doctorDetail)
        {
            if (string.IsNullOrWhiteSpace(_searchString)) return true;
            if (doctorDetail.DoctorName?.Contains(_searchString, StringComparison.OrdinalIgnoreCase) == true)
            {
                return true;
            }
            if (doctorDetail.Department?.Contains(_searchString, StringComparison.OrdinalIgnoreCase) == true)
            {
                return true;
            }
            return false;
        }
    }
}
