using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using WarehouseManger.Application.Features.PatientVisits.Commands.AddEdit;
using WarehouseManger.Application.Features.PatientVisits.Queries.GetAllPaged;
using WarehouseManger.Application.Requests.Clinic;
using WarehouseManger.Client.Infrastructure.Extensions;
using WarehouseManger.Shared.Wrapper;

namespace WarehouseManger.Client.Infrastructure.Managers.Clinic
{
   

    public class PatientVisitManager : IPatientVisitManager
    {
        private readonly HttpClient _httpClient;

        public PatientVisitManager(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<IResult<int>> DeleteAsync(int id)
        {
            var response = await _httpClient.DeleteAsync($"{Routes.PatientVisitsEndpoints.Delete}/{id}");
            return await response.ToResult<int>();
        }

        public async Task<IResult<string>> ExportToExcelAsync(int patientId , string searchString = "" )
        {
            var response = await _httpClient.GetAsync(string.IsNullOrWhiteSpace(searchString)
                ? Routes.PatientVisitsEndpoints.ExportFiltered(patientId)
                : Routes.PatientVisitsEndpoints.ExportFiltered( patientId , searchString));
            return await response.ToResult<string>();
        }



        public async Task<PaginatedResult<GetAllPagedPatientVisitsResponse>> GetPatientVisitsAsync(GetAllPagedPatientVisitRequest request)
        {
            var response = await _httpClient.GetAsync(Routes.PatientVisitsEndpoints.GetAllPaged(request.PageNumber, request.PageSize, request.SearchString, request.Orderby, request.PatientId));
            return await response.ToPaginatedResult<GetAllPagedPatientVisitsResponse>();
        }

        public async Task<IResult<int>> SaveAsync(AddEditPatientVisitCommand request)
        {
            var response = await _httpClient.PostAsJsonAsync(Routes.PatientVisitsEndpoints.Save, request);
            return await response.ToResult<int>();
        }
    }
}
