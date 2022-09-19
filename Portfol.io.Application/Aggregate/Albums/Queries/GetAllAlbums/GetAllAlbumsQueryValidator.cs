using FluentValidation;

namespace Portfol.io.Application.Aggregate.Albums.Queries.GetAllAlbums
{
    public class GetAllAlbumsQueryValidator : AbstractValidator<GetAllAlbumsQuery>
    {
        public GetAllAlbumsQueryValidator()
        {
            RuleFor(getAllAlbumsQuery => getAllAlbumsQuery.UserId)
                .NotEqual(Guid.Empty).WithMessage("UserId is required.");
        }
    }
}
