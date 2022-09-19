using FluentValidation;

namespace Portfol.io.Application.Aggregate.Albums.Queries.GetMarkedAlbums
{
    public class GetMarkedAlbumsQueryValidator : AbstractValidator<GetMarkedAlbumsQuery>
    {
        public GetMarkedAlbumsQueryValidator()
        {
            RuleFor(getMarkedAlbumsQuery => getMarkedAlbumsQuery.UserId)
                .NotEqual(Guid.Empty).WithMessage("UserId is required");
        }
    }
}
