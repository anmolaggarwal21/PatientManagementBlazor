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

namespace WarehouseManger.Application.Features.Patients.Queries.Export
{
    public class ExportPatientQuery : IRequest<Result<string>>
    {
        public string SearchString { get; set; }

        public ExportPatientQuery(string searchString = "")
        {
            SearchString = searchString;
        }
    }

    internal class ExportPatientQueryHandler : IRequestHandler<ExportPatientQuery, Result<string>>
    {
        private readonly IExcelService _excelService;
        private readonly IUnitOfWork<int> _unitOfWork;

        public ExportPatientQueryHandler(IExcelService excelService
            , IUnitOfWork<int> unitOfWork)
        {
            _excelService = excelService;
            _unitOfWork = unitOfWork;
           
        }

        public async Task<Result<string>> Handle(ExportPatientQuery request, CancellationToken cancellationToken)
        {
            var patientFilterSpec = new PatientFilterSpecification(request.SearchString);
            var products = await _unitOfWork.Repository<Patient>().Entities
                                            .Specify(patientFilterSpec)
                                            .ToListAsync( cancellationToken);
            var data = await _excelService.ExportAsync(products, mappers: new Dictionary<string, Func<Patient, object>>
            {
                {  "Id", item => item.Id },
                {  "FirstName", item => item.FirstName },
                {  "LastName", item => item.LastName },
                {  "OPDId", item => item.OPDId },
                {  "Email Address", item => item.EmailAddress },
                {  "Date Of Birth", item => item.DateOfBirth }
            }, sheetName:  "Patients");

            return await Result<string>.SuccessAsync(data: data);
        }
    }
}