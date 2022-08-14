using MediatR;
using Microsoft.EntityFrameworkCore;
using Portfol.io.Application.Common.Exceptions;
using Portfol.io.Application.Interfaces;
using Portfol.io.Domain;

namespace Portfol.io.Application.Aggregate.Albums.Commands.AddImage
{
    public class AddImageCommandHandler : IRequestHandler<AddImageCommand, Unit>
    {
        private readonly IPortfolioDbContext _dbContext;
        private readonly IImageUploader _uploader;

        public AddImageCommandHandler(IPortfolioDbContext dbContext, IImageUploader uploader)
        {
            _dbContext = dbContext;
            _uploader = uploader;
        }

        public async Task<Unit> Handle(AddImageCommand request, CancellationToken cancellationToken)
        {
            var entity = await _dbContext.Albums.FirstOrDefaultAsync(u => u.Id == request.Model.AlbumId, cancellationToken);

            if (entity is null || entity.Id != request.Model.AlbumId) throw new NotFoundException(nameof(Album), request.Model.AlbumId);

            _uploader.File = request.Model.ImageFile;
            _uploader.AbsolutePath = $"{request.Model.WebRootPath}/AlbumImages/{entity.Id}/";
            var imagePath = await _uploader.Upload();

            await _dbContext.Photos.AddAsync(new Photo
            {
                Path = imagePath,
                AlbumId = request.Model.AlbumId
            }, cancellationToken);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
