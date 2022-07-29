using WarehouseManger.Application.Extensions;
using WarehouseManger.Application.Interfaces.Repositories;
using WarehouseManger.Application.Specifications.Catalog;
using WarehouseManger.Domain.Entities.Catalog;
using WarehouseManger.Shared.Wrapper;
using MediatR;
using System;
using System.Linq;
using System.Linq.Expressions;
using System.Linq.Dynamic.Core;
using System.Threading;
using System.Threading.Tasks;
using WarehouseManger.Domain.Entities.Clinic;
using WarehouseManger.Application.Specifications.Clinic;

namespace WarehouseManger.Application.Features.PatientVisits.Queries.GetAllPaged
{
    public class GetAllPatientVisitsQuery : IRequest<PaginatedResult<GetAllPagedPatientVisitsResponse>>
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public string SearchString { get; set; }

        public int PatientId { get; set; }
        public string[] OrderBy { get; set; } // of the form fieldname [ascending|descending],fieldname [ascending|descending]...

        public GetAllPatientVisitsQuery(int pageNumber, int pageSize, string searchString, string orderBy, int patientId)
        {
            PageNumber = pageNumber;
            PageSize = pageSize;
            SearchString = searchString;
            PatientId = patientId;
            if (!string.IsNullOrWhiteSpace(orderBy))
            {
                OrderBy = orderBy.Split(',');
            }
        }
    }

    internal class GetAllPatientVisitsQueryHandler : IRequestHandler<GetAllPatientVisitsQuery, PaginatedResult<GetAllPagedPatientVisitsResponse>>
    {
        private readonly IUnitOfWork<int> _unitOfWork;

        public GetAllPatientVisitsQueryHandler(IUnitOfWork<int> unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<PaginatedResult<GetAllPagedPatientVisitsResponse>> Handle(GetAllPatientVisitsQuery request, CancellationToken cancellationToken)
        {
            Expression<Func<PatientVisit, GetAllPagedPatientVisitsResponse>> expression = e => new GetAllPagedPatientVisitsResponse
            {
                Id = e.Id,
                PatientVisitId = e.PatientVisitId,
                admission = e.admission,
                Amount = e.Amount,
                DateOfDischarge = e.DateOfDischarge,
                DateOfVisit = e.DateOfVisit,
                DoctorDetailsId = e.DoctorDetailsId,
                PaymentType = e.PaymentType,
                Treatment   = e.Treatment
                
            };
            var patientVisitFilterSpec = new PatientVisitFilterSpecification(request.SearchString, request.PatientId);
            if (request.OrderBy?.Any() != true)
            {
                var data = await _unitOfWork.Repository<PatientVisit>().Entities
                   .Specify(patientVisitFilterSpec)
                   .Select(expression)
                   .ToPaginatedListAsync(request.PageNumber, request.PageSize);
                return data;
            }
            else
            {
                var ordering = string.Join(",", request.OrderBy); // of the form fieldname [ascending|descending], ...
                var data = await _unitOfWork.Repository<PatientVisit>().Entities
                   .Specify(patientVisitFilterSpec)
                   .OrderBy(ordering) // require system.linq.dynamic.core
                   .Select(expression)
                   .ToPaginatedListAsync(request.PageNumber, request.PageSize);
                return data;

            }
        }
    }
}