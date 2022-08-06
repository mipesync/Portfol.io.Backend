using FluentValidation;

namespace Portfol.io.Application.Aggregate.Users.Commands.UpdateUser
{
    public class UpdateUserCommandValidator : AbstractValidator<UpdateUserCommand>
    {
        public UpdateUserCommandValidator()
        {
            RuleFor(updateUserCommand => updateUserCommand.Id)
                .NotEqual(Guid.Empty).WithMessage("Id is required");

            RuleFor(updateUserCommand => updateUserCommand.Name)
                .NotEmpty().WithMessage("Name is required.");

            RuleFor(updateUserCommand => updateUserCommand.Description)
                .MaximumLength(500).WithMessage("The description lenght must be less than 500.");

            RuleFor(updateUserCommand => updateUserCommand.DateOfBirth)
                .NotEqual(default(DateOnly));

            RuleFor(updateUserCommand => updateUserCommand.Phone)
                .Length(10, 20);

            RuleFor(updateUserCommand => updateUserCommand.Email)
                .NotEmpty().WithMessage("Email is required.")
                .EmailAddress().WithMessage("Doesn't match the email format.");
        }
    }
}
