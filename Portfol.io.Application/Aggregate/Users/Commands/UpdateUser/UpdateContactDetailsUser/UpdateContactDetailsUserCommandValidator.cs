using FluentValidation;

namespace Portfol.io.Application.Aggregate.Users.Commands.UpdateUser.UpdateContactDetailsUser
{
    public class UpdateContactDetailsUserCommandValidator : AbstractValidator<UpdateContactDetailsUserCommand>
    {
        public UpdateContactDetailsUserCommandValidator()
        {
            RuleFor(updateContactDetailsUserCommand => updateContactDetailsUserCommand.Id)
                .NotEqual(Guid.Empty).WithMessage("Id is required");

            RuleFor(updateContactDetailsUserCommand => updateContactDetailsUserCommand.Phone)
                .NotEmpty().WithMessage("Phone is required.")
                .Length(10, 20).WithMessage("The phone lenght must be greater than 10 and less than 20."); ;

            RuleFor(updateContactDetailsUserCommand => updateContactDetailsUserCommand.Email)
                .NotEmpty().WithMessage("Email is required.")
                .EmailAddress().WithMessage("Doesn't match the email format.");

            RuleFor(updateContactDetailsUserCommand => updateContactDetailsUserCommand.VerifyCode)
                .NotEmpty().WithMessage("Verify code is required.")
                .Length(6).WithMessage("The verify code lenght should be 6.");
        }
    }
}
