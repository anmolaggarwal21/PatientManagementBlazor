using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using WarehouseManger.Application.Features.Patients.Commands.Delete;
using WarehouseManger.Application.Features.PatientVisits.Commands.AddEdit;
using WarehouseManger.Application.Features.PatientVisits.Queries.Export;
using WarehouseManger.Application.Features.PatientVisits.Queries.GetAllPaged;
using WarehouseManger.Shared.Constants.Permission;

namespace WarehouseManger.Server.Controllers.v1.Clinic
{
    

    public class PatientVisitController : BaseApiController<PatientVisitController>
    {
        /// <summary>
        /// Get All Patient Visits
        /// </summary>
        /// <param name="patientId"></param>
        /// <param name="pageNumber"></param>
        /// <param name="pageSize"></param>
        /// <param name="searchString"></param>
        /// <param name="orderBy"></param>
        /// <returns>Status 200 OK</returns>
        [Authorize(Policy = Permissions.PatientVisit.View)]
        [HttpGet("{patientId}")]
        public async Task<IActionResult> GetAll(int patientId, int pageNumber, int pageSize, string searchString, string orderBy = null)
        {
            var patientVisits = await _mediator.Send(new GetAllPatientVisitsQuery(pageNumber, pageSize, searchString, orderBy, patientId));
            return Ok(patientVisits);
        }




        /// <summary>
        /// Add/Edit a Patient Visit
        /// </summary>
        /// <param name="command"></param>
        /// <returns>Status 200 OK</returns>
        [Authorize(Policy = Permissions.PatientVisit.Create)]
        [HttpPost()]
        public async Task<IActionResult> Post( AddEditPatientVisitCommand command)
        {
            return Ok(await _mediator.Send(command));
        }

        /// <summary>
        /// Delete a Patient Visit
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Status 200 OK response</returns>
        [Authorize(Policy = Permissions.PatientVisit.Delete)]
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            return Ok(await _mediator.Send(new DeletePatientVisitCommand { Id = id }));
        }

        /// <summary>
        /// Search Patients Visit and Export to Excel
        /// </summary>
        /// <param name="patientId"></param>
        /// <param name="searchString"></param>
        /// <returns>Status 200 OK</returns>
        [Authorize(Policy = Permissions.PatientVisit.Export)]
        [HttpGet("export/{patientId}")]
        public async Task<IActionResult> Export(int patientId, string searchString = "")
        {
            return Ok(await _mediator.Send(new ExportPatientVisitQuery(patientId, searchString)));
        }
    }
}
