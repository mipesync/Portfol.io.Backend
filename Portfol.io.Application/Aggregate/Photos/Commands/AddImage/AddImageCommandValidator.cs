using FluentValidation;
using Microsoft.AspNetCore.Http;

namespace Portfol.io.Application.Aggregate.Photos.Commands.AddImage
{
    public class AddImageCommandValidator : AbstractValidator<AddImageCommand>
    {
        public AddImageCommandValidator()
        {
            RuleFor(addImageCommand => addImageCommand.ImageFile)
                .NotEqual(default(IFormFile)).WithMessage("Image file is required");

            RuleFor(addImageCommand => addImageCommand.WebRootPath)
                .NotEmpty().WithMessage("WebRootPath is required.");

            RuleFor(addImageCommand => addImageCommand.HostUrl)
                .NotEmpty().WithMessage("HostUrl is required.");

            RuleFor(addImageCommand => addImageCommand.AlbumId)
                .NotEqual(Guid.Empty).WithMessage("AlbumId is required");
        }
    }
}

