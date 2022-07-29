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
    public class DeletePatientCommand : IRequest<Result<int>>
    {
        public int Id { get; set; }
    }

    internal class DeletePatientCommandHandler : IRequestHandler<DeletePatientCommand, Result<int>>
    {
        private readonly IUnitOfWork<int> _unitOfWork;
        private readonly IStringLocalizer<DeletePatientCommandHandler> _localizer;

        public DeletePatientCommandHandler(IUnitOfWork<int> unitOfWork, IStringLocalizer<DeletePatientCommandHandler> localizer)
        {
            _unitOfWork = unitOfWork;
            _localizer = localizer;
        }

        public async Task<Result<int>> Handle(DeletePatientCommand command, CancellationToken cancellationToken)
        {
            var patient = await _unitOfWork.Repository<Patient>().GetByIdAsync(command.Id);
            if (patient != null)
            {
                await _unitOfWork.Repository<Patient>().DeleteAsync(patient);
                await _unitOfWork.Commit(cancellationToken);
                return await Result<int>.SuccessAsync(patient.Id, "Patient Deleted");
            }
            else
            {
                return await Result<int>.FailAsync("Patient Not Found");
            }
        }
    }
}