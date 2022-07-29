using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WarehouseManger.Application.Features.PatientVisits.Commands.AddEdit;
using WarehouseManger.Application.Features.PatientVisits.Queries.GetAllPaged;
using WarehouseManger.Application.Requests.Clinic;
using WarehouseManger.Shared.Wrapper;

namespace WarehouseManger.Client.Infrastructure.Managers.Clinic
{
   
    public interface IPatientVisitManager : IManager
    {
        Task<PaginatedResult<GetAllPagedPatientVisitsResponse>> GetPatientVisitsAsync(GetAllPagedPatientVisitRequest request);

        Task<IResult<int>> SaveAsync(AddEditPatientVisitCommand request);

        Task<IResult<int>> DeleteAsync(int id);

        Task<IResult<string>> ExportToExcelAsync(int patientId, string searchString = "");
    }
}
