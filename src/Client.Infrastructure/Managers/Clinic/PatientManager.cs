using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using WarehouseManger.Application.Features.Patients.Commands.AddEdit;
using WarehouseManger.Application.Features.Patients.Queries.GetAllPaged;
using WarehouseManger.Application.Features.Patients.Queries.GetById;
using WarehouseManger.Application.Requests.Clinic;
using WarehouseManger.Client.Infrastructure.Extensions;
using WarehouseManger.Shared.Wrapper;

namespace WarehouseManger.Client.Infrastructure.Managers.Clinic
{


    public class PatientManager : IPatientManager
    {
        private readonly HttpClient _httpClient;

        public PatientManager(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<IResult<int>> DeleteAsync(int id)
        {
            var response = await _httpClient.DeleteAsync($"{Routes.PatientsEndpoints.Delete}/{id}");
            return await response.ToResult<int>();
        }

        public async Task<IResult<string>> ExportToExcelAsync(string searchString = "")
        {
            var response = await _httpClient.GetAsync(string.IsNullOrWhiteSpace(searchString)
                ? Routes.PatientsEndpoints.Export
                : Routes.PatientsEndpoints.ExportFiltered(searchString));
            return await response.ToResult<string>();
        }

        

        public async Task<PaginatedResult<GetAllPagedPatientsResponse>> GetPatientsAsync(GetAllPagedPatientsRequest request)
        {
            var response = await _httpClient.GetAsync(Routes.PatientsEndpoints.GetAllPaged(request.PageNumber, request.PageSize, request.SearchString, request.Orderby));
            return await response.ToPaginatedResult<GetAllPagedPatientsResponse>();
        }

        public async Task<IResult<int>> SaveAsync(AddEditPatientCommand request)
        {
            var response = await _httpClient.PostAsJsonAsync(Routes.PatientsEndpoints.Save, request);
            return await response.ToResult<int>();
        }

       public async Task<IResult<GetPatientsByIdResponse>> GetPatientById(int patientId)
       {
            var response = await _httpClient.GetAsync(Routes.PatientsEndpoints.GetPatientDetailsById(patientId));
            return await response.ToResult<GetPatientsByIdResponse>();
       }
    }
}
