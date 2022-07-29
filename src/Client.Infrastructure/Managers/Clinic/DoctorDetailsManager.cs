using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using WarehouseManger.Application.Features.Brands.Commands.AddEdit;
using WarehouseManger.Application.Features.Brands.Queries.GetAll;
using WarehouseManger.Application.Features.Doctors.Commands.AddEdit;
using WarehouseManger.Application.Features.Doctors.Queries.GetAll;
using WarehouseManger.Client.Infrastructure.Extensions;
using WarehouseManger.Shared.Wrapper;

namespace WarehouseManger.Client.Infrastructure.Managers.Clinic
{
    public class DoctorDetailsManager : IDoctorDetailsManager
    {
        private readonly HttpClient _httpClient;

        public DoctorDetailsManager(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<IResult<int>> DeleteAsync(int id)
        {
            var response = await _httpClient.DeleteAsync($"{Routes.DoctorDetailsEndpoints.Delete}/{id}");
            return await response.ToResult<int>();
        }

        public async Task<IResult<string>> ExportToExcelAsync(string searchString = "")
{
            var response = await _httpClient.GetAsync(string.IsNullOrWhiteSpace(searchString)
                           ? Routes.DoctorDetailsEndpoints.Export
                           : Routes.DoctorDetailsEndpoints.ExportFiltered(searchString));
            return await response.ToResult<string>();
        }

        public  async Task<IResult<List<GetAllDoctorDetailsResponse>>> GetAllAsync()
        {
            var response = await _httpClient.GetAsync(Routes.DoctorDetailsEndpoints.GetAll);
            return await response.ToResult<List<GetAllDoctorDetailsResponse>>();
        }

        public async Task<IResult<int>> SaveAsync(AddEditDoctorDetailsCommand request)
        {
            var response = await _httpClient.PostAsJsonAsync(Routes.DoctorDetailsEndpoints.Save, request);
            return await response.ToResult<int>();
        }
    }
}
