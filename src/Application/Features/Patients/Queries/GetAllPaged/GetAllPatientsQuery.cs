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

namespace WarehouseManger.Application.Features.Patients.Queries.GetAllPaged
{
    public class GetAllPatientsQuery : IRequest<PaginatedResult<GetAllPagedPatientsResponse>>
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public string SearchString { get; set; }
        public string[] OrderBy { get; set; } // of the form fieldname [ascending|descending],fieldname [ascending|descending]...

        public GetAllPatientsQuery(int pageNumber, int pageSize, string searchString, string orderBy)
        {
            PageNumber = pageNumber;
            PageSize = pageSize;
            SearchString = searchString;
            if (!string.IsNullOrWhiteSpace(orderBy))
            {
                OrderBy = orderBy.Split(',');
            }
        }
    }

    internal class GetAllPatientsQueryHandler : IRequestHandler<GetAllPatientsQuery, PaginatedResult<GetAllPagedPatientsResponse>>
    {
        private readonly IUnitOfWork<int> _unitOfWork;

        public GetAllPatientsQueryHandler(IUnitOfWork<int> unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<PaginatedResult<GetAllPagedPatientsResponse>> Handle(GetAllPatientsQuery request, CancellationToken cancellationToken)
        {
            Expression<Func<Patient, GetAllPagedPatientsResponse>> expression = e => new GetAllPagedPatientsResponse
            {
                Id = e.Id,
                Address = e.Address,
                DateOfBirth = e.DateOfBirth,
                EmailAddress = e.EmailAddress,
                FirstName = e.FirstName,
                Gender = e.Gender,
                LastName = e.LastName,   
                OPDId = e.OPDId,
                PatientId = e.PatientId,
                PhoneNumber=e.PhoneNumber
            };
            var productFilterSpec = new PatientFilterSpecification(request.SearchString);
            if (request.OrderBy?.Any() != true)
            {
                var data = await _unitOfWork.Repository<Patient>().Entities
                   .Specify(productFilterSpec)
                   .Select(expression)
                   .ToPaginatedListAsync(request.PageNumber, request.PageSize);
                return data;
            }
            else
            {
                var ordering = string.Join(",", request.OrderBy); // of the form fieldname [ascending|descending], ...
                var data = await _unitOfWork.Repository<Patient>().Entities
                   .Specify(productFilterSpec)
                   .OrderBy(ordering) // require system.linq.dynamic.core
                   .Select(expression)
                   .ToPaginatedListAsync(request.PageNumber, request.PageSize);
                return data;

            }
        }
    }
}