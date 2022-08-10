using MediatR;
using Microsoft.EntityFrameworkCore;
using Portfol.io.Application.Common.Exceptions;
using Portfol.io.Application.Interfaces;

namespace Portfol.io.Application.Aggregate.Users.Commands.UpdateUserImage
{
    public class UpdateUserImageCommandHandler : IRequestHandler<UpdateUserImageCommand, Unit>
    {
        private readonly IPortfolioDbContext _dbContext;

        public UpdateUserImageCommandHandler(IPortfolioDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Unit> Handle(UpdateUserImageCommand request, CancellationToken cancellationToken)
        {
            var file = request.Model.ImageFile;
            var fileExtension = Path.GetExtension(file.FileName);
            var fileNameHash = Guid.NewGuid().ToString();

            string path = "/ProfileImages/" + fileNameHash + fileExtension;
            using (var fileStream = new FileStream(request.Model.WebRootPath + path, FileMode.Create))
            {
                await file.CopyToAsync(fileStream);
            }

            var entity = await _dbContext.Users.FirstOrDefaultAsync(u => u.Id == request.Model.UserId, cancellationToken);

            if (entity == null || entity.Id != request.Model.UserId) throw new NotFoundException(nameof(Users), request.Model.UserId);

            entity.ProfileImagePath = path;

            await _dbContext.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
