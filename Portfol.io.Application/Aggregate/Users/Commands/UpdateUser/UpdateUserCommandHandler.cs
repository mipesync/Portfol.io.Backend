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
            var entity = await _dbContext.Users.FirstOrDefaultAsync(u => u.Id == request.Model.Id, cancellationToken);

            if (entity == null || entity.Id != request.Model.Id) throw new NotFoundException(nameof(User), request.Model.Id);

            entity.Name = request.Model.Name;
            entity.Description = request.Model.Description;
            entity.DateOfBirth = request.Model.DateOfBirth;

            await _dbContext.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
