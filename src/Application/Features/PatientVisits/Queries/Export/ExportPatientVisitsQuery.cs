using WarehouseManger.Application.Interfaces.Repositories;
using WarehouseManger.Application.Interfaces.Services;
using WarehouseManger.Domain.Entities.Catalog;
using MediatR;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using WarehouseManger.Application.Extensions;
using WarehouseManger.Application.Specifications.Catalog;
using WarehouseManger.Shared.Wrapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Localization;
using WarehouseManger.Application.Specifications.Clinic;
using WarehouseManger.Domain.Entities.Clinic;

namespace WarehouseManger.Application.Features.PatientVisits.Queries.Export
{
    public class ExportPatientVisitQuery : IRequest<Result<string>>
    {
        public string SearchString { get; set; }
        public int PatientId { get; set; }

        public ExportPatientVisitQuery(int patientId , string searchString = "")
        {
            SearchString = searchString;
            PatientId = patientId;
        }
    }

    internal class ExportPatientVisitQueryHandler : IRequestHandler<ExportPatientVisitQuery, Result<string>>
    {
        private readonly IExcelService _excelService;
        private readonly IUnitOfWork<int> _unitOfWork;

        public ExportPatientVisitQueryHandler(IExcelService excelService
            , IUnitOfWork<int> unitOfWork
            , IStringLocalizer<ExportPatientVisitQueryHandler> localizer)
        {
            _excelService = excelService;
            _unitOfWork = unitOfWork;
        }

        public async Task<Result<string>> Handle(ExportPatientVisitQuery request, CancellationToken cancellationToken)
        {
            var patientFilterSpec = new PatientVisitFilterSpecification(request.SearchString, request.PatientId);
            var products = await _unitOfWork.Repository<PatientVisit>().Entities
                                            .Specify(patientFilterSpec)
                                            .ToListAsync( cancellationToken);
            var data = await _excelService.ExportAsync(products, mappers: new Dictionary<string, Func<PatientVisit, object>>
            {
                {  "Id", item => item.Id },
                {  "Date Of Visit", item => item.DateOfVisit },
                {  "Patient Visit Id", item => item.PatientVisitId },
                {  "Admission", item => item.admission },
                {  "Amount", item => item.Amount },
                {  "Date Of Discharge", item => item.DateOfDischarge },
                {  "Doctor Details Id", item => item.DoctorDetailsId },
                {  "Date Of Visit", item => item.DateOfVisit }
            }, sheetName:  "PatientVisits");

            return await Result<string>.SuccessAsync(data: data);
        }
    }
}