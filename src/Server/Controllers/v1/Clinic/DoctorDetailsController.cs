using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using WarehouseManger.Application.Features.Doctors.Commands.AddEdit;
using WarehouseManger.Application.Features.Doctors.Commands.Delete;
using WarehouseManger.Application.Features.Doctors.Queries.Export;
using WarehouseManger.Application.Features.Doctors.Queries.GetAll;
using WarehouseManger.Application.Features.Doctors.Queries.GetById;
using WarehouseManger.Shared.Constants.Permission;

namespace WarehouseManger.Server.Controllers.v1.Clinic
{
    public class DoctorDetailsController : BaseApiController<DoctorDetailsController>
    {
        /// <summary>
        /// Get All DoctorDetails
        /// </summary>
        /// <returns>Status 200 OK</returns>
        [Authorize(Policy = Permissions.DoctorDetails.View)]
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var doctorDetails = await _mediator.Send(new GetAllDoctorDetailsQuery());
            return Ok(doctorDetails);
        }

        /// <summary>
        /// Get a Doctor Details By Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Status 200 Ok</returns>
        [Authorize(Policy = Permissions.DoctorDetails.View)]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var doctorDetails = await _mediator.Send(new GetDoctorDetailsByIdQuery() { Id = id });
            return Ok(doctorDetails);
        }

        /// <summary>
        /// Create/Update a DoctorDetails
        /// </summary>
        /// <param name="command"></param>
        /// <returns>Status 200 OK</returns>
        [Authorize(Policy = Permissions.DoctorDetails.Create)]
        [HttpPost]
        public async Task<IActionResult> Post(AddEditDoctorDetailsCommand command)
        {
            return Ok(await _mediator.Send(command));
        }

        /// <summary>
        /// Delete a DoctorDetails
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Status 200 OK</returns>
        [Authorize(Policy = Permissions.DoctorDetails.Delete)]
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            return Ok(await _mediator.Send(new DeleteDoctorDetailsCommand { Id = id }));
        }

        /// <summary>
        /// Search DoctorDetails and Export to Excel
        /// </summary>
        /// <param name="searchString"></param>
        /// <returns></returns>
        [Authorize(Policy = Permissions.DoctorDetails.Export)]
        [HttpGet("export")]
        public async Task<IActionResult> Export(string searchString = "")
        {
            return Ok(await _mediator.Send(new ExportDoctorDetailsQuery(searchString)));
        }
    }
}
