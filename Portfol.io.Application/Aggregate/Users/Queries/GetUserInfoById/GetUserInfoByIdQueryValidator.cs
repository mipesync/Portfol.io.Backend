using FluentValidation;

namespace Portfol.io.Application.Aggregate.Users.Queries.GetUserInfoById
{
    public class GetUserInfoByIdQueryValidator : AbstractValidator<GetUserInfoByIdQuery>
    {
        public GetUserInfoByIdQueryValidator()
        {
            RuleFor(getUserInfoByIdQuery => getUserInfoByIdQuery.UserId)
                .NotEqual(Guid.Empty).WithMessage("UserId is required");
        }
    }
}
