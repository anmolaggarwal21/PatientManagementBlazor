using AutoMapper;
using LazyCache;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using WarehouseManger.Application.Interfaces.Repositories;
using WarehouseManger.Domain.Entities.Clinic;
using WarehouseManger.Shared.Constants.Application;
using WarehouseManger.Shared.Wrapper;

namespace WarehouseManger.Application.Features.Doctors.Queries.GetAll
{
    

    public class GetAllDoctorDetailsQuery : IRequest<Result<List<GetAllDoctorDetailsResponse>>>
    {
        public GetAllDoctorDetailsQuery()
        {
        }
    }

    internal class GetAllDoctorDetailsQueryHandler : IRequestHandler<GetAllDoctorDetailsQuery, Result<List<GetAllDoctorDetailsResponse>>>
    {
        private readonly IUnitOfWork<int> _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IAppCache _cache;

        public GetAllDoctorDetailsQueryHandler(IUnitOfWork<int> unitOfWork, IMapper mapper, IAppCache cache)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _cache = cache;
        }

        public async Task<Result<List<GetAllDoctorDetailsResponse>>> Handle(GetAllDoctorDetailsQuery request, CancellationToken cancellationToken)
        {
            Func<Task<List<DoctorDetails>>> getAllDoctorDetails = () => _unitOfWork.Repository<DoctorDetails>().GetAllAsync();
            var doc = await getAllDoctorDetails();
            var doctorDetailsList = await _cache.GetOrAddAsync(ApplicationConstants.Cache.GetAllDoctorDetails, getAllDoctorDetails);
            var mappedBrands = _mapper.Map<List<GetAllDoctorDetailsResponse>>(doctorDetailsList);
            return await Result<List<GetAllDoctorDetailsResponse>>.SuccessAsync(mappedBrands);
        }
    }
}
