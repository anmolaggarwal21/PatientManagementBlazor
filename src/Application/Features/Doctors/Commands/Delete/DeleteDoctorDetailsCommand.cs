using MediatR;
using Microsoft.Extensions.Localization;
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

namespace WarehouseManger.Application.Features.Doctors.Commands.Delete
{
    

    public class DeleteDoctorDetailsCommand : IRequest<Result<int>>
    {
        public int Id { get; set; }
    }

    internal class DeleteDoctorDetailsCommandHandler : IRequestHandler<DeleteDoctorDetailsCommand, Result<int>>
    {
        private readonly IProductRepository _productRepository;
        private readonly IStringLocalizer<DeleteDoctorDetailsCommandHandler> _localizer;
        private readonly IUnitOfWork<int> _unitOfWork;

        public DeleteDoctorDetailsCommandHandler(IUnitOfWork<int> unitOfWork,  IStringLocalizer<DeleteDoctorDetailsCommandHandler> localizer)
        {
            _unitOfWork = unitOfWork;
            _localizer = localizer;
        }

        public async Task<Result<int>> Handle(DeleteDoctorDetailsCommand command, CancellationToken cancellationToken)
        {
           
            var doctorDetails = await _unitOfWork.Repository<DoctorDetails>().GetByIdAsync(command.Id);
            if (doctorDetails != null)
            {
                await _unitOfWork.Repository<DoctorDetails>().DeleteAsync(doctorDetails);
                await _unitOfWork.CommitAndRemoveCache(cancellationToken, ApplicationConstants.Cache.GetAllDoctorDetails);
                return await Result<int>.SuccessAsync(doctorDetails.Id, "Doctor Details Deleted");
            }
            else
            {
                return await Result<int>.FailAsync("Doctor Details Not Found");
            }
            
        }
    }
}
