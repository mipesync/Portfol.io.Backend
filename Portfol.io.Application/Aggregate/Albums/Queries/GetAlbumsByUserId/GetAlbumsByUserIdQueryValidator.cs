using FluentValidation;

namespace Portfol.io.Application.Aggregate.Albums.Queries.GetAlbumsByUserId
{
    public class GetAlbumsByUserIdQueryValidator : AbstractValidator<GetAlbumsByUserIdQuery>
    {
        public GetAlbumsByUserIdQueryValidator()
        {
            RuleFor(u => u.UserId)
                .NotEqual(Guid.Empty).WithMessage("UserId is required.");
        }
    }
}
