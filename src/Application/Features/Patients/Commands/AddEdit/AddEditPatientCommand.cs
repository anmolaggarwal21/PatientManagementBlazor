using System.ComponentModel.DataAnnotations;
using AutoMapper;
using WarehouseManger.Application.Interfaces.Repositories;
using WarehouseManger.Application.Interfaces.Services;
using WarehouseManger.Application.Requests;
using WarehouseManger.Domain.Entities.Catalog;
using WarehouseManger.Shared.Wrapper;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Localization;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using WarehouseManger.Domain.Entities.Clinic;
using WarehouseManger.Domain.Enums;
using System;

namespace WarehouseManger.Application.Features.Patients.Commands.AddEdit
{
    public partial class AddEditPatientCommand : IRequest<Result<int>>
    {
        public int Id { get; set; }

        public string OPDId { get; set; }
        [Required]
        public string EmailAddress { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        public DateTime? DateOfBirth { get; set; }
        [Required]
        public Gender Gender { get; set; }
        [Required]
        public long PhoneNumber { get; set; }

        public string Address { get; set; }
    }

    internal class AddEditPatientCommandHandler : IRequestHandler<AddEditPatientCommand, Result<int>>
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork<int> _unitOfWork;

        public AddEditPatientCommandHandler(IUnitOfWork<int> unitOfWork, IMapper mapper, IUploadService uploadService, IStringLocalizer<AddEditPatientCommandHandler> localizer)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            
        }

        public async Task<Result<int>> Handle(AddEditPatientCommand command, CancellationToken cancellationToken)
        {
            

            if (command.Id == 0)
            {
                var patient = _mapper.Map<Patient>(command);
                patient.PatientId = Guid.NewGuid();
                patient.OPDId = $"{DateTime.Now.ToString("yyyyMMddHHmmss")}";
                await _unitOfWork.Repository<Patient>().AddAsync(patient);
                await _unitOfWork.Commit(cancellationToken);
                return await Result<int>.SuccessAsync(patient.Id, "Patient Saved");
            }
            else
            {
                var patient = await _unitOfWork.Repository<Patient>().GetByIdAsync(command.Id);
                if (patient != null)
                {
                    patient.FirstName = command.FirstName ?? patient.FirstName;
                    patient.EmailAddress = command.EmailAddress ?? patient.EmailAddress;
                    patient.Address = command.Address ?? patient.Address;
                    patient.PhoneNumber = command.PhoneNumber ;   
                    patient.Gender = command.Gender ;  

                    patient.LastName = command.LastName ?? patient.LastName;
                    patient.DateOfBirth =   command.DateOfBirth.Equals(DateTime.MinValue) ? patient.DateOfBirth : command.DateOfBirth ;

                    await _unitOfWork.Repository<Patient>().UpdateAsync(patient);
                    await _unitOfWork.Commit(cancellationToken);
                    return await Result<int>.SuccessAsync(patient.Id, "Patient Updated");
                }
                else
                {
                    return await Result<int>.FailAsync("Patient Not Found");
                }
            }
        }
    }
}