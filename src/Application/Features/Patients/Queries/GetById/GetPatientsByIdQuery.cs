using AutoMapper;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using WarehouseManger.Application.Features.Patients.Queries.GetAllPaged;
using WarehouseManger.Application.Interfaces.Repositories;
using WarehouseManger.Domain.Entities.Clinic;
using WarehouseManger.Shared.Wrapper;

namespace WarehouseManger.Application.Features.Patients.Queries.GetById
{
    public class GetPatientsByIdQuery : IRequest<Result<GetPatientsByIdResponse>>
    {
        public int Id { get; set; }
    }

    public class GetPatientsByIdQueryHandler : IRequestHandler<GetPatientsByIdQuery, Result<GetPatientsByIdResponse>>
    {
        private readonly IUnitOfWork<int> _unitOfWork;
        private readonly IMapper _mapper;

        public GetPatientsByIdQueryHandler(IUnitOfWork<int> unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Result<GetPatientsByIdResponse>> Handle(GetPatientsByIdQuery query, CancellationToken cancellationToken)
        {
            var patient = await _unitOfWork.Repository<Patient>().GetByIdAsync(query.Id);
            var mappedPatient = _mapper.Map<GetPatientsByIdResponse>(patient);
            return await Result<GetPatientsByIdResponse>.SuccessAsync(mappedPatient);
        }
    }
}