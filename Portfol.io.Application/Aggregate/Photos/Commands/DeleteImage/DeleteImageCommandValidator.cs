using FluentValidation;

namespace Portfol.io.Application.Aggregate.Photos.Commands.DeleteImage
{
    public class DeleteImageCommandValidator : AbstractValidator<DeleteImageCommand>
    {
        public DeleteImageCommandValidator()
        {
            RuleFor(u => u.AlbumId)
                .NotEmpty().WithMessage("Id is required.");

            RuleFor(u => u.PhotoId)
                .NotEmpty().WithMessage("AlbumId is required.");

            RuleFor(u => u.WebRootPath)
                .NotEmpty().WithMessage("WebRootPath is required");
        }
    }
}
