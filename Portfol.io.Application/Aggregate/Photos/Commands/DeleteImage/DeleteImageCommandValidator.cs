using FluentValidation;

namespace Portfol.io.Application.Aggregate.Photos.Commands.DeleteImage
{
    public class DeleteImageCommandValidator : AbstractValidator<DeleteImageCommand>
    {
        public DeleteImageCommandValidator()
        {
            RuleFor(u => u.AlbumId)
                .NotEqual(Guid.Empty).WithMessage("AlbumId is required");

            RuleFor(u => u.ImageId)
                .NotEqual(Guid.Empty).WithMessage("PhotoId is required");

            RuleFor(u => u.WebRootPath)
                .NotEmpty().WithMessage("WebRootPath is required");
        }
    }
}
