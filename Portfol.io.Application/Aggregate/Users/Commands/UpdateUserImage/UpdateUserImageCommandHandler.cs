using MediatR;
using Microsoft.EntityFrameworkCore;
using Portfol.io.Application.Common.Exceptions;
using Portfol.io.Application.Interfaces;

namespace Portfol.io.Application.Aggregate.Users.Commands.UpdateUserImage
{
    public class UpdateUserImageCommandHandler : IRequestHandler<UpdateUserImageCommand, Unit>
    {
        private readonly IPortfolioDbContext _dbContext;
        private readonly IImageUploader _uploader;

        public UpdateUserImageCommandHandler(IPortfolioDbContext dbContext, IImageUploader uploader)
        {
            _dbContext = dbContext;
            _uploader = uploader;
        }

        public async Task<Unit> Handle(UpdateUserImageCommand request, CancellationToken cancellationToken)
        {
            var entity = await _dbContext.Users.FirstOrDefaultAsync(u => u.Id == request.UserId, cancellationToken);

            if (entity == null || entity.Id != request.UserId) throw new NotFoundException(nameof(Users), request.UserId);

            if (entity.ProfileImagePath != "/ProfileImages/default.png") File.Delete($"{request.WebRootPath}{entity.ProfileImagePath}");

            _uploader.File = request.ImageFile;
            _uploader.AbsolutePath = $"{request.WebRootPath}/ProfileImages/{entity.Id}/";
            var imagePath = await _uploader.Upload();

            entity.ProfileImagePath = imagePath;

            await _dbContext.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
