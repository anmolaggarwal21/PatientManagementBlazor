using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using WarehouseManger.Application.Extensions;
using WarehouseManger.Application.Interfaces.Repositories;
using WarehouseManger.Application.Interfaces.Services;
using WarehouseManger.Application.Specifications.Catalog;
using WarehouseManger.Domain.Entities.Catalog;
using WarehouseManger.Shared.Wrapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Localization;
using WarehouseManger.Domain.Entities.Clinic;
using WarehouseManger.Application.Specifications.Clinic;

namespace WarehouseManger.Application.Features.Doctors.Queries.Export
{
    public class ExportDoctorDetailsQuery : IRequest<Result<string>>
    {
        public string SearchString { get; set; }

        public ExportDoctorDetailsQuery(string searchString = "")
        {
            SearchString = searchString;
        }
    }

    internal class ExportDoctorDetailsQueryHandler : IRequestHandler<ExportDoctorDetailsQuery, Result<string>>
    {
        private readonly IExcelService _excelService;
        private readonly IUnitOfWork<int> _unitOfWork;
        private readonly IStringLocalizer<ExportDoctorDetailsQueryHandler> _localizer;

        public ExportDoctorDetailsQueryHandler(IExcelService excelService
            , IUnitOfWork<int> unitOfWork
            , IStringLocalizer<ExportDoctorDetailsQueryHandler> localizer)
        {
            _excelService = excelService;
            _unitOfWork = unitOfWork;
            _localizer = localizer;
        }

        public async Task<Result<string>> Handle(ExportDoctorDetailsQuery request, CancellationToken cancellationToken)
        {
            var doctorFilterSpec = new DoctorDetailsFilterSpecification(request.SearchString);
            var doctorDetails = await _unitOfWork.Repository<DoctorDetails>().Entities
                .Specify(doctorFilterSpec)
                .ToListAsync(cancellationToken);
            var data = await _excelService.ExportAsync(doctorDetails, mappers: new Dictionary<string, Func<DoctorDetails, object>>
            {
                { _localizer["Id"], item => item.Id },
                { "Doctor Name", item => item.DoctorName },
                { "Department", item => item.Department },
                { "Date Of Birth", item => item.DateOfBirth }
            }, sheetName: "Doctor Details");

            return await Result<string>.SuccessAsync(data: data);
        }
    }
}
