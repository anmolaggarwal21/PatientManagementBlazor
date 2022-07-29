using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WarehouseManger.Application.Features.Doctors.Commands.AddEdit;

namespace WarehouseManger.Application.Validators.Features.DoctorDetails.Commands.AddEdit
{
    

    public class AddEditDoctorDetailsCommandValidator : AbstractValidator<AddEditDoctorDetailsCommand>
    {
        public AddEditDoctorDetailsCommandValidator()
        {
            RuleFor(request => request.DoctorName)
                .MaximumLength(100).WithMessage(x => $" Doctor  Name Cannot be greater than 100")
                .Must(x => !string.IsNullOrWhiteSpace(x)).WithMessage(x => "Doctor Name is required") ;
            RuleFor(request => request.Department)
                .MaximumLength(100).WithMessage(x => $" Department Cannot be greater than 100")
                .Must(x => !string.IsNullOrWhiteSpace(x)).WithMessage(x => "Department is required");
            RuleFor(request => request.DateOfBirth)
                  .Must(x =>  x != DateTime.MinValue && x!= null).WithMessage(x => "Date Of Birth is required");
        }
    }
}
