using FluentValidation;

namespace Portfol.io.Application.Aggregate.Users.Queries.GetUserById
{
    public class GetUserByIdQueryValidator : AbstractValidator<GetUserByIdQuery>
    {
        public GetUserByIdQueryValidator()
        {
            RuleFor(getUserByIdQuery => getUserByIdQuery.Id)
                .NotEqual(Guid.Empty).WithMessage("Id is required");
        }
    }
}
