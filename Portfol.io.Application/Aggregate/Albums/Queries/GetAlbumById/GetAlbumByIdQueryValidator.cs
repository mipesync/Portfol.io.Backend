using FluentValidation;

namespace Portfol.io.Application.Aggregate.Albums.Queries.GetAlbumById
{
    public class GetAlbumByIdQueryValidator : AbstractValidator<GetAlbumByIdQuery>
    {
        public GetAlbumByIdQueryValidator()
        {
            RuleFor(getAlbumByIdQuery => getAlbumByIdQuery.Id)
                .NotEqual(Guid.Empty).WithMessage("Id is required");
        }
    }
}
