using FluentValidation;

namespace Portfol.io.Application.Aggregate.Photos.Commands.AddImage
{
    public class AddImageCommandValidator : AbstractValidator<AddImageCommand>
    {
        public AddImageCommandValidator()
        {
            RuleFor(addImageCommand => addImageCommand.Files.Count)
                .GreaterThan(0).WithMessage("Image is required");

            RuleFor(addImageCommand => addImageCommand.WebRootPath)
                .NotEmpty().WithMessage("WebRootPath is required");

            RuleFor(addImageCommand => addImageCommand.AlbumId)
                .NotEqual(Guid.Empty).WithMessage("AlbumId is required");
        }
    }
}

