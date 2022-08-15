using MediatR;
using Microsoft.EntityFrameworkCore;
using Portfol.io.Application.Common.Exceptions;
using Portfol.io.Application.Interfaces;
using Portfol.io.Domain;

namespace Portfol.io.Application.Aggregate.Users.Commands.UpdateUser
{
    public class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommand, Unit>
    {
        private readonly IPortfolioDbContext _dbContext;

        public UpdateUserCommandHandler(IPortfolioDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Unit> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
        {
            var entity = await _dbContext.Users.FirstOrDefaultAsync(u => u.Id == request.Id, cancellationToken);

            if (entity == null || entity.Id != request.Id) throw new NotFoundException(nameof(User), request.Id);

            entity.Name = request.Name;
            entity.Description = request.Description;
            entity.DateOfBirth = request.DateOfBirth;

            await _dbContext.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
