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

namespace WarehouseManger.Application.Features.PatientVisits.Commands.AddEdit
{
    public partial class AddEditPatientVisitCommand : IRequest<Result<int>>
    {
        public int Id { get; set; }

        public Guid? PatientVisitId { get; set; }

        [Required]
        public DateTime? DateOfVisit { get; set; }

        [Required]
        public AdmissionType admission { get; set; }

        public int? PatientDetailsId { get; set; }

        [Required]
        public decimal Amount { get; set; }

        public int DoctorDetailsId { get; set; }

        public string? Treatment { get; set; }

        [Required]
        public PaymentType PaymentType { get; set; }

        public DateTime? DateOfDischarge { get; set; }
    }

    internal class AddEditPatientVisitCommandHandler : IRequestHandler<AddEditPatientVisitCommand, Result<int>>
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork<int> _unitOfWork;

        public AddEditPatientVisitCommandHandler(IUnitOfWork<int> unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            
        }

        public async Task<Result<int>> Handle(AddEditPatientVisitCommand command, CancellationToken cancellationToken)
        {
            

            if (command.Id == 0)
            {
                var patientVisit = _mapper.Map<PatientVisit>(command);
                patientVisit.PatientVisitId = Guid.NewGuid();
              //  patientVisit.OPDId = $"{DateTime.Now.ToString("yyyyMMddHHmmss")}";
                await _unitOfWork.Repository<PatientVisit>().AddAsync(patientVisit);
                await _unitOfWork.Commit(cancellationToken);
                return await Result<int>.SuccessAsync(patientVisit.Id, "Patient Visit Saved");
            }
            else
            {
                var patientVisit = await _unitOfWork.Repository<PatientVisit>().GetByIdAsync(command.Id);
                if (patientVisit != null)
                {
                    patientVisit.DateOfVisit = command.DateOfVisit;
                    patientVisit.admission = command.admission;
                    patientVisit.Treatment = command.Treatment ?? patientVisit.Treatment;
                    patientVisit.PatientVisitId = command.PatientVisitId;   
                    patientVisit.Amount = command.Amount  ;  
                    patientVisit.DateOfDischarge = command.DateOfDischarge ?? patientVisit.DateOfDischarge;
                    patientVisit.DoctorDetailsId = command.DoctorDetailsId;
                    patientVisit.PaymentType = command.PaymentType;

                    await _unitOfWork.Repository<PatientVisit>().UpdateAsync(patientVisit);
                    await _unitOfWork.Commit(cancellationToken);
                    return await Result<int>.SuccessAsync(patientVisit.Id, "Patient Visit Updated");
                }
                else
                {
                    return await Result<int>.FailAsync("Patient Visit Not Found");
                }
            }
        }
    }
}