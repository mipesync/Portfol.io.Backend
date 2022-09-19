using FluentValidation;
using Microsoft.AspNetCore.Http;

namespace Portfol.io.Application.Aggregate.Albums.Commands.UpdateAlbumCover
{
    public class UpdateAlbumCoverCommandValidator : AbstractValidator<UpdateAlbumCoverCommand>
    {
        public UpdateAlbumCoverCommandValidator()
        {
            RuleFor(updateAlbumCoverCommand => updateAlbumCoverCommand.Image)
                .NotEqual(default(IFormFile)).WithMessage("Image is required");

            RuleFor(updateAlbumCoverCommand => updateAlbumCoverCommand.WebRootPath)
                .NotEmpty().WithMessage("WebRootPath is required");

            RuleFor(updateAlbumCoverCommand => updateAlbumCoverCommand.AlbumId)
                .NotEqual(Guid.Empty).WithMessage("AlbumId is required");

            RuleFor(updateAlbumCoverCommand => updateAlbumCoverCommand.UserId)
                .NotEqual(Guid.Empty).WithMessage("UserId is required");
        }
    }
}
