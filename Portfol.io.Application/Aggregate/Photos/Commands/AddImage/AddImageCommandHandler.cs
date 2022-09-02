using MediatR;
using Microsoft.EntityFrameworkCore;
using Portfol.io.Application.Common.Exceptions;
using Portfol.io.Application.Interfaces;
using Portfol.io.Domain;

namespace Portfol.io.Application.Aggregate.Photos.Commands.AddImage
{
    public class AddImageCommandHandler : IRequestHandler<AddImageCommand, Guid>
    {
        private readonly IPortfolioDbContext _dbContext;
        private readonly IImageUploader _uploader;

        public AddImageCommandHandler(IPortfolioDbContext dbContext, IImageUploader uploader)
        {
            _dbContext = dbContext;
            _uploader = uploader;
        }

        public async Task<Guid> Handle(AddImageCommand request, CancellationToken cancellationToken)
        {
            var entity = await _dbContext.Albums.FirstOrDefaultAsync(u => u.Id == request.AlbumId, cancellationToken);

            if (entity is null || entity.Id != request.AlbumId) throw new NotFoundException(nameof(Album), request.AlbumId);

            _uploader.File = request.ImageFile;
            _uploader.AbsolutePath = $"{request.WebRootPath}/AlbumImages/{entity.UserId}/{entity.Id}/";
            var imagePath = await _uploader.Upload();

            var photo = new Photo
            {
                Path = imagePath,
                AlbumId = request.AlbumId
            };

            await _dbContext.Photos.AddAsync(photo, cancellationToken);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return photo.Id;
        }
    }
}
