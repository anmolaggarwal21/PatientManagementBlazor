using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WarehouseManger.Application.Features.Brands.Commands.AddEdit;
using WarehouseManger.Application.Features.Brands.Queries.GetAll;
using WarehouseManger.Application.Features.Doctors.Commands.AddEdit;
using WarehouseManger.Application.Features.Doctors.Queries.GetAll;
using WarehouseManger.Shared.Wrapper;

namespace WarehouseManger.Client.Infrastructure.Managers.Clinic
{
  

    public interface IDoctorDetailsManager : IManager
    {
        Task<IResult<List<GetAllDoctorDetailsResponse>>> GetAllAsync();

        Task<IResult<int>> SaveAsync(AddEditDoctorDetailsCommand request);

        Task<IResult<int>> DeleteAsync(int id);

        Task<IResult<string>> ExportToExcelAsync(string searchString = "");
    }
}
