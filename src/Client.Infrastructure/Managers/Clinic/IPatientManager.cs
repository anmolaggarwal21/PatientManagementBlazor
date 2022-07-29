using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WarehouseManger.Application.Features.Patients.Commands.AddEdit;
using WarehouseManger.Application.Features.Patients.Queries.GetAllPaged;
using WarehouseManger.Application.Features.Patients.Queries.GetById;
using WarehouseManger.Application.Requests.Clinic;
using WarehouseManger.Shared.Wrapper;

namespace WarehouseManger.Client.Infrastructure.Managers.Clinic
{
    
    public interface IPatientManager : IManager
    {
        Task<PaginatedResult<GetAllPagedPatientsResponse>> GetPatientsAsync(GetAllPagedPatientsRequest request);

        Task<IResult<int>> SaveAsync(AddEditPatientCommand request);

        Task<IResult<int>> DeleteAsync(int id);

        Task<IResult<string>> ExportToExcelAsync(string searchString = "");

        Task<IResult<GetPatientsByIdResponse>> GetPatientById(int id);

    }
}
