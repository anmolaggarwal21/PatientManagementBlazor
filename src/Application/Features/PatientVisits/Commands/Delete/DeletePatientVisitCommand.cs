using WarehouseManger.Application.Interfaces.Repositories;
using WarehouseManger.Domain.Entities.Catalog;
using WarehouseManger.Shared.Wrapper;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Localization;
using WarehouseManger.Domain.Entities.Clinic;

namespace WarehouseManger.Application.Features.Patients.Commands.Delete
{
    public class DeletePatientVisitCommand : IRequest<Result<int>>
    {
        public int Id { get; set; }
    }

    internal class DeletePatientVisitCommandHandler : IRequestHandler<DeletePatientVisitCommand, Result<int>>
    {
        private readonly IUnitOfWork<int> _unitOfWork;

        public DeletePatientVisitCommandHandler(IUnitOfWork<int> unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Result<int>> Handle(DeletePatientVisitCommand command, CancellationToken cancellationToken)
        {
            var patientVisit = await _unitOfWork.Repository<PatientVisit>().GetByIdAsync(command.Id);
            if (patientVisit != null)
            {
                await _unitOfWork.Repository<PatientVisit>().DeleteAsync(patientVisit);
                await _unitOfWork.Commit(cancellationToken);
                return await Result<int>.SuccessAsync(patientVisit.Id, "Patient Visit Deleted");
            }
            else
            {
                return await Result<int>.FailAsync("Patient Visit Not Found");
            }
        }
    }
}