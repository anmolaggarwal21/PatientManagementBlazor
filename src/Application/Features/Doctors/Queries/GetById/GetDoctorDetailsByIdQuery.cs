using AutoMapper;
using WarehouseManger.Application.Interfaces.Repositories;
using WarehouseManger.Domain.Entities.Catalog;
using WarehouseManger.Shared.Wrapper;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using WarehouseManger.Domain.Entities.Clinic;
using System;

namespace WarehouseManger.Application.Features.Doctors.Queries.GetById
{
    public class GetDoctorDetailsByIdQuery : IRequest<Result<GetDoctorDetailsByIdResponse>>
    {
        public int Id { get; set; }
    }

    internal class GetDoctorDetailsByIdQueryHandler : IRequestHandler<GetDoctorDetailsByIdQuery, Result<GetDoctorDetailsByIdResponse>>
    {
        private readonly IUnitOfWork<int> _unitOfWork;
        private readonly IMapper _mapper;

        public GetDoctorDetailsByIdQueryHandler(IUnitOfWork<int> unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Result<GetDoctorDetailsByIdResponse>> Handle(GetDoctorDetailsByIdQuery query, CancellationToken cancellationToken)
        {
            var brand = await _unitOfWork.Repository<DoctorDetails>().GetByIdAsync(query.Id);
            var mappedBrand = _mapper.Map<GetDoctorDetailsByIdResponse>(brand);
            return await Result<GetDoctorDetailsByIdResponse>.SuccessAsync(mappedBrand);
        }
    }
}