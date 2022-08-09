using FluentValidation;

namespace Portfol.io.Application.Aggregate.Users.Commands.CreateUser
{
    public class CreateUserCommandValidator : AbstractValidator<CreateUserCommand>
    {
        public CreateUserCommandValidator()
        {
            RuleFor(createUserCommand => createUserCommand.Model)
                .NotEmpty().WithMessage("Model is required.");

            RuleFor(createUserCommand => createUserCommand.Model.Name)
                .NotEmpty().WithMessage("Name is required.");

            RuleFor(createUserCommand => createUserCommand.Model.Description)
                .MaximumLength(500).WithMessage("The description lenght must be less than 500.");

            RuleFor(createUserCommand => createUserCommand.Model.DateOfBirth)
                .NotEqual(default(DateOnly));

            RuleFor(createUserCommand => createUserCommand.Model.Phone)
                .Length(10, 20);

            RuleFor(createUserCommand => createUserCommand.Model.Email)
                .NotEmpty().WithMessage("Email is required.")
                .EmailAddress().WithMessage("Doesn't match the email format.");

            RuleFor(createUserCommand => createUserCommand.Model.CredentialsId)
                .NotEmpty().WithMessage("CredentialId is required.")
                .GreaterThan(0).WithMessage("The CredentialId lenght must not be less than 0.");

            RuleFor(createUserCommand => createUserCommand.Model.RoleId)
                .NotEmpty().WithMessage("RoleId is required.")
                .GreaterThan(0).WithMessage("The RoleId lenght must not be less than 0.");
        }
    }
}
