


using Blazored.FluentValidation;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.SignalR.Client;
using MudBlazor;
using System.Threading.Tasks;
using WarehouseManger.Application.Features.Patients.Commands.AddEdit;
using WarehouseManger.Client.Extensions;
using WarehouseManger.Client.Infrastructure.Managers.Clinic;
using WarehouseManger.Shared.Constants.Application;

namespace WarehouseManger.Client.Pages.Clinic
{
    public partial class AddEditPatientModal
    {
        [Inject] private IPatientManager PatientManager { get; set; }

        [Parameter] public AddEditPatientCommand AddEditPatientModel { get; set; } = new();
        [CascadingParameter] private HubConnection HubConnection { get; set; }
        [CascadingParameter] private MudDialogInstance MudDialog { get; set; }

        private FluentValidationValidator _fluentValidationValidator;
        private bool Validated => _fluentValidationValidator.Validate(options => { options.IncludeAllRuleSets(); });
       

        public void Cancel()
        {
            MudDialog.Cancel();
        }

        private async Task SaveAsync()
        {
            var response = await PatientManager.SaveAsync(AddEditPatientModel);
            if (response.Succeeded)
            {
                _snackBar.Add(response.Messages[0], Severity.Success);
                await HubConnection.SendAsync(ApplicationConstants.SignalR.SendUpdateDashboard);
                MudDialog.Close();
            }
            else
            {
                foreach (var message in response.Messages)
                {
                    _snackBar.Add(message, Severity.Error);
                }
            }
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
          //  await LoadImageAsync();
           // await LoadBrandsAsync();
        }

       

      
    }
}