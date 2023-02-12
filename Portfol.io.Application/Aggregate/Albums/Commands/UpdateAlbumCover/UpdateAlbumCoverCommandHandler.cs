using MediatR;
using Microsoft.EntityFrameworkCore;
using Portfol.io.Application.Common.Exceptions;
using Portfol.io.Application.Interfaces;
using Portfol.io.Domain;

namespace Portfol.io.Application.Aggregate.Albums.Commands.UpdateAlbumCover
{
    public class UpdateAlbumCoverCommandHandler : IRequestHandler<UpdateAlbumCoverCommand, Unit>
    {
        private readonly IPortfolioDbContext _dbContext;
        private readonly IImageUploader _imageUploader;

        public UpdateAlbumCoverCommandHandler(IPortfolioDbContext dbContext, IImageUploader imageUploader)
        {
            _dbContext = dbContext;
            _imageUploader = imageUploader;
        }

        public async Task<Unit> Handle(UpdateAlbumCoverCommand request, CancellationToken cancellationToken)
        {
            var entity = await _dbContext.Albums.FirstOrDefaultAsync(u => u.Id == request.AlbumId, cancellationToken);

            if (entity is null || entity.Id != request.AlbumId)
                throw new NotFoundException(nameof(Album), request.AlbumId);

            if (entity.UserId != request.UserId)
                throw new Exception("Вы не можете редактировать чужой альбом");

            if (entity.Cover != null)
                File.Delete(String.Concat(request.WebRootPath, entity.Cover!));

            _imageUploader.WebRootPath = request.WebRootPath is null
                ? throw new ArgumentException("WebRootPath не может быть пустым")
                : request.WebRootPath;

            _imageUploader.AbsolutePath = $"/AlbumCovers/{entity.UserId}/{entity.Id}";
            _imageUploader.File = request.Image;

            var imagePath = await _imageUploader.Upload();

            entity.Cover = imagePath;

            await _dbContext.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
