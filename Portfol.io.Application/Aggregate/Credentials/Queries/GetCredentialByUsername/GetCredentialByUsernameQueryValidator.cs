using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portfol.io.Application.Aggregate.Credentials.Queries.GetCredentialByUsername
{
    public class GetCredentialByUsernameQueryValidator : AbstractValidator<GetCredentialByUsernameQuery>
    {
        public GetCredentialByUsernameQueryValidator()
        {
            RuleFor(getCredentialByUsernameQuery => getCredentialByUsernameQuery.Username)
                .NotEmpty().WithMessage("Username is required.")
                .MinimumLength(5).WithMessage("The username lenght must not be less than 5.");
        }
    }
}
