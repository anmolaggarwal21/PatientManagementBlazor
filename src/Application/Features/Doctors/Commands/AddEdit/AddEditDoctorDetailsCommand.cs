using AutoMapper;
using MediatR;
using Microsoft.Extensions.Localization;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using WarehouseManger.Application.Interfaces.Repositories;
using WarehouseManger.Domain.Entities.Clinic;
using WarehouseManger.Shared.Constants.Application;
using WarehouseManger.Shared.Wrapper;

namespace WarehouseManger.Application.Features.Doctors.Commands.AddEdit
{
    
   

    public partial class AddEditDoctorDetailsCommand : IRequest<Result<int>>
    {
        public int Id { get; set; }
        public Guid DoctorId { get; set; }
        [Required]
        [MaxLength(100)]
        public string DoctorName { get; set; }
        [Required]
        [MaxLength(100)]
        public string Department { get; set; }
        [Required]
        public DateTime? DateOfBirth { get; set; } 
    }

    internal class AddEditDoctorDetailsCommandHandler : IRequestHandler<AddEditDoctorDetailsCommand, Result<int>>
    {
        private readonly IMapper _mapper;
        private readonly IStringLocalizer<AddEditDoctorDetailsCommandHandler> _localizer;
        private readonly IUnitOfWork<int> _unitOfWork;

        public AddEditDoctorDetailsCommandHandler(IUnitOfWork<int> unitOfWork, IMapper mapper, IStringLocalizer<AddEditDoctorDetailsCommandHandler> localizer)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _localizer = localizer;
        }

        public async Task<Result<int>> Handle(AddEditDoctorDetailsCommand command, CancellationToken cancellationToken)
        {
            if (command.Id == 0)
            {
                var doctorDetails = _mapper.Map<DoctorDetails>(command);
                doctorDetails.DoctorId = Guid.NewGuid();
                await _unitOfWork.Repository<DoctorDetails>().AddAsync(doctorDetails);
                await _unitOfWork.CommitAndRemoveCache(cancellationToken, ApplicationConstants.Cache.GetAllDoctorDetails);
                return await Result<int>.SuccessAsync(doctorDetails.Id, "Doctor Details Saved");
            }
            else
            {
                var doctorDetails = await _unitOfWork.Repository<DoctorDetails>().GetByIdAsync(command.Id);
                if (doctorDetails != null)
                {
                    doctorDetails.DoctorName = command.DoctorName ?? doctorDetails.DoctorName;
                    doctorDetails.Department = command.Department ?? doctorDetails.Department;
                    doctorDetails.DateOfBirth = command.DateOfBirth == DateTime.MinValue ? doctorDetails.DateOfBirth : command.DateOfBirth;
                    await _unitOfWork.Repository<DoctorDetails>().UpdateAsync(doctorDetails);
                    await _unitOfWork.CommitAndRemoveCache(cancellationToken, ApplicationConstants.Cache.GetAllDoctorDetails);
                    return await Result<int>.SuccessAsync(doctorDetails.Id, "Doctor Details Updated");
                }
                else
                {
                    return await Result<int>.FailAsync("Doctor Details Not Found");
                }
            }
        }
    }
}
