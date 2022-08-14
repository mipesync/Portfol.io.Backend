using FluentValidation;
using Microsoft.AspNetCore.Http;

namespace Portfol.io.Application.Aggregate.Albums.Commands.AddImage
{
    public class AddImageCommandValidator : AbstractValidator<AddImageCommand>
    {
        public AddImageCommandValidator()
        {
            RuleFor(addImageCommand => addImageCommand.Model.ImageFile)
                .NotEqual(default(IFormFile)).WithMessage("Image file is required");

            RuleFor(addImageCommand => addImageCommand.Model.WebRootPath)
                .NotEmpty().WithMessage("WebRootPath is required.");

            RuleFor(addImageCommand => addImageCommand.Model.HostUrl)
                .NotEmpty().WithMessage("HostUrl is required.");

            RuleFor(addImageCommand => addImageCommand.Model.AlbumId)
                .NotEqual(0).WithMessage("AlbumId is required.");
        }
    }
}

