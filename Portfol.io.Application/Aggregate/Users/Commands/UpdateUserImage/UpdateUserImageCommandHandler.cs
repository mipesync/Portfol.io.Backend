using MediatR;
using Microsoft.EntityFrameworkCore;
using Portfol.io.Application.Common.Exceptions;
using Portfol.io.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            var file = request.ImageFile;
            var fileExtension = Path.GetExtension(file.FileName);
            var fileNameHash = Guid.NewGuid().ToString();

            string path = "/ProfileImages/" + fileNameHash + fileExtension;
            using (var fileStream = new FileStream(request.WebRootPath + path, FileMode.Create))
            {
                await file.CopyToAsync(fileStream);
            }

            var entity = await _dbContext.Users.FirstOrDefaultAsync(u => u.Id == request.UserId, cancellationToken);

            if (entity == null || entity.Id != request.UserId) throw new NotFoundException(nameof(Users), request.UserId);

            entity.ProfileImagePath = path;

            await _dbContext.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
