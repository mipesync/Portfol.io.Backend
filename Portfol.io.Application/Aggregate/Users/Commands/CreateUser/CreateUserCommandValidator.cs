using FluentValidation;

namespace Portfol.io.Application.Aggregate.Users.Commands.CreateUser
{
    public class CreateUserCommandValidator : AbstractValidator<CreateUserCommand>
    {
        public CreateUserCommandValidator()
        {
            RuleFor(createUserCommand => createUserCommand.Name)
                .NotEmpty().WithMessage("Name is required.");

            RuleFor(createUserCommand => createUserCommand.Description)
                .MaximumLength(500).WithMessage("The description lenght must be less than 500.");

            RuleFor(createUserCommand => createUserCommand.DateOfBirth)
                .NotEqual(default(DateOnly));

            RuleFor(createUserCommand => createUserCommand.Phone)
                .Length(10, 20);

            RuleFor(createUserCommand => createUserCommand.Email)
                .NotEmpty().WithMessage("Email is required.")
                .EmailAddress().WithMessage("Doesn't match the email format.");

            RuleFor(createUserCommand => createUserCommand.CredentialsId)
                .NotEmpty().WithMessage("CredentialId is required.")
                .GreaterThan(0).WithMessage("The CredentialId lenght must not be less than 0.");

            RuleFor(createUserCommand => createUserCommand.RoleId)
                .NotEmpty().WithMessage("RoleId is required.")
                .GreaterThan(0).WithMessage("The RoleId lenght must not be less than 0.");
        }
    }
}
