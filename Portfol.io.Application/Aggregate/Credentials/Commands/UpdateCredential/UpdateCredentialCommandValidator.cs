using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portfol.io.Application.Aggregate.Credentials.Commands.UpdateCredential
{
    public class UpdateCredentialCommandValidator : AbstractValidator<UpdateCredentialCommand>
    {
        public UpdateCredentialCommandValidator()
        {
            RuleFor(updateCredentialCommand => updateCredentialCommand.Username)
                .NotEmpty().WithMessage("Username is required.")
                .MinimumLength(5).WithMessage("The username lenght must not be less than 5.");
        }
    }
}
