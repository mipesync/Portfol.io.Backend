using FluentValidation;

namespace Portfol.io.Application.Aggregate.Albums.Queries.GetAlbumsByTags
{
    public class GetAlbumsByTagsQueryValidator : AbstractValidator<GetAlbumsByTagsQuery>
    {
        public GetAlbumsByTagsQueryValidator()
        {
            RuleFor(getAlbumsByTagsQueryValidator => getAlbumsByTagsQueryValidator.TagIds)
                .NotEqual(default(IEnumerable<Guid>));
            RuleFor(getAlbumsByTagsQueryValidator => getAlbumsByTagsQueryValidator.UserId)
                .NotEqual(Guid.Empty).WithMessage("UserId is required."); ;
        }
    }
}
