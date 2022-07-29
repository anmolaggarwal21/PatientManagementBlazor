using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using WarehouseManger.Application.Features.Patients.Commands.AddEdit;
using WarehouseManger.Application.Features.Patients.Commands.Delete;
using WarehouseManger.Application.Features.Patients.Queries.Export;
using WarehouseManger.Application.Features.Patients.Queries.GetAllPaged;
using WarehouseManger.Application.Features.Patients.Queries.GetById;
using WarehouseManger.Shared.Constants.Permission;

namespace WarehouseManger.Server.Controllers.v1.Clinic
{
    public class PatientController : BaseApiController<PatientController>
    {
        /// <summary>
        /// Get All Patients
        /// </summary>
        /// <param name="pageNumber"></param>
        /// <param name="pageSize"></param>
        /// <param name="searchString"></param>
        /// <param name="orderBy"></param>
        /// <returns>Status 200 OK</returns>
        [Authorize(Policy = Permissions.Patient.View)]
        [HttpGet]
        public async Task<IActionResult> GetAll(int pageNumber, int pageSize, string searchString, string orderBy = null)
        {
            var patients = await _mediator.Send(new GetAllPatientsQuery(pageNumber, pageSize, searchString, orderBy));
            return Ok(patients);
        }

        [Authorize(Policy = Permissions.Patient.View)]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetAll(int id)
        {
            var patients = await _mediator.Send(new GetPatientsByIdQuery() { Id = id });
            return Ok(patients);
        }


        /// <summary>
        /// Add/Edit a Patient
        /// </summary>
        /// <param name="command"></param>
        /// <returns>Status 200 OK</returns>
        [Authorize(Policy = Permissions.Patient.Create)]
        [HttpPost]
        public async Task<IActionResult> Post(AddEditPatientCommand command)
        {
            return Ok(await _mediator.Send(command));
        }

        /// <summary>
        /// Delete a Patient
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Status 200 OK response</returns>
        [Authorize(Policy = Permissions.Patient.Delete)]
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            return Ok(await _mediator.Send(new DeletePatientCommand { Id = id }));
        }

        /// <summary>
        /// Search Patients and Export to Excel
        /// </summary>
        /// <param name="searchString"></param>
        /// <returns>Status 200 OK</returns>
        [Authorize(Policy = Permissions.Patient.Export)]
        [HttpGet("export")]
        public async Task<IActionResult> Export(string searchString = "")
        {
            return Ok(await _mediator.Send(new ExportPatientQuery(searchString)));
        }
    }
}
