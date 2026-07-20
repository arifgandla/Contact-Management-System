using Contact_Management.DTOs;
using FluentValidation;

namespace Contact_Management.API.Validations
{
    public class ContactDTOValidator : AbstractValidator<ContactDTO>
    {
        public ContactDTOValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Contact Name is required.")
                .MinimumLength(3).WithMessage("Contact Name must be at least 3 characters.")
                .MaximumLength(100).WithMessage("Contact Name cannot exceed 100 characters.");

            RuleFor(x => x.Email)
                .NotEmpty().WithMessage("Email is required.")
                .EmailAddress().WithMessage("Invalid Email Address.");

            RuleFor(x => x.Phone)
                .NotEmpty().WithMessage("Phone Number is required.")
                .Matches(@"^[6-9]\d{9}$")
                .WithMessage("Phone Number must be a valid 10-digit Indian mobile number.");
        }
    }
}