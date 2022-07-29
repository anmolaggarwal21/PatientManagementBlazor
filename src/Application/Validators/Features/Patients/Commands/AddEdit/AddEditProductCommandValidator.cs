using WarehouseManger.Application.Features.Products.Commands.AddEdit;
using FluentValidation;
using Microsoft.Extensions.Localization;
using WarehouseManger.Application.Features.Patients.Commands.AddEdit;

namespace WarehouseManger.Application.Validators.Features.Patients.Commands.AddEdit
{
    public class AddEditPatientCommandValidator : AbstractValidator<AddEditPatientCommand>
    {
        public AddEditPatientCommandValidator()
        {
            RuleFor(request => request.FirstName)
                .Must(x => !string.IsNullOrWhiteSpace(x)).WithMessage(x => "First Name is required");
            RuleFor(request => request.LastName)
                .Must(x => !string.IsNullOrWhiteSpace(x)).WithMessage(x => "Last Name is required");
            RuleFor(request => request.EmailAddress)
                .Must(x => !string.IsNullOrWhiteSpace(x)).WithMessage(x => "Email Address is required");
            RuleFor(request => request.PhoneNumber)
                .GreaterThan(0).WithMessage(x => "Phone Number is required");
            RuleFor(request => request.Gender)
                .Must(x => x != null ).WithMessage(x => "Gender is required");

            RuleFor(request => request.DateOfBirth)
                .Must(x => x!= null || x!= System.DateTime.MinValue).WithMessage(x => "Date Of Birth is required");

            RuleFor(request => request.Address)
            .Must(x => !string.IsNullOrWhiteSpace(x)).WithMessage(x => "Address is required");

        }
    }
}