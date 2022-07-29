﻿using Blazored.FluentValidation;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.SignalR.Client;
using MudBlazor;
using System;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using WarehouseManger.Application.Features.Doctors.Commands.AddEdit;
using WarehouseManger.Client.Extensions;
using WarehouseManger.Client.Infrastructure.Managers.Clinic;
using WarehouseManger.Shared.Constants.Application;

namespace WarehouseManger.Client.Pages.Clinic
{

    public partial class AddOrEditDoctorDetailsModal
    {

        [Inject] private IDoctorDetailsManager DoctorDetailsManager { get; set; }

        [Parameter] public AddEditDoctorDetailsCommand AddEditDoctorDetailsModel { get; set; } = new();
        [CascadingParameter] private MudDialogInstance MudDialog { get; set; }
        [CascadingParameter] private HubConnection HubConnection { get; set; }


        [Required]
        public DateTime? dateOfBirthOfDoctor = DateTime.Today;

        private FluentValidationValidator _fluentValidationValidator;
        private bool Validated => _fluentValidationValidator.Validate(options => { options.IncludeAllRuleSets(); });

        public void Cancel()
        {
            MudDialog.Cancel();
        }

        private async Task SaveAsync()
        {
            
            var response = await DoctorDetailsManager.SaveAsync(AddEditDoctorDetailsModel);
            if (response.Succeeded)
            {
                _snackBar.Add(response.Messages[0], Severity.Success);
                MudDialog.Close();
            }
            else
            {
                foreach (var message in response.Messages)
                {
                    _snackBar.Add(message, Severity.Error);
                }
            }
            await HubConnection.SendAsync(ApplicationConstants.SignalR.SendUpdateDashboard);
        }

        protected override async Task OnInitializedAsync()
        {
            await LoadDataAsync();

            HubConnection = HubConnection.TryInitialize(_navigationManager);
            if (HubConnection.State == HubConnectionState.Disconnected)
            {
                await HubConnection.StartAsync();
            }
        }

        private async Task LoadDataAsync()
        {
            if (AddEditDoctorDetailsModel.DateOfBirth == null || AddEditDoctorDetailsModel.DateOfBirth.Equals(DateTime.MinValue))
            {
                dateOfBirthOfDoctor = DateTime.Today;
            }
            else
                dateOfBirthOfDoctor = AddEditDoctorDetailsModel.DateOfBirth;
            await Task.CompletedTask;
        }
    }
}
