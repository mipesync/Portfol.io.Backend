using MediatR;
using Microsoft.EntityFrameworkCore;
using Portfol.io.Application.Common.Exceptions;
using Portfol.io.Application.Interfaces;
using Portfol.io.Domain;

namespace Portfol.io.Application.Aggregate.Credentials.Commands.UpdateCredential
{
    public class UpdateCredentialCommandHandler : IRequestHandler<UpdateCredentialCommand, Unit>
    {
        private readonly IPortfolioDbContext _dbContext;

        public UpdateCredentialCommandHandler(IPortfolioDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Unit> Handle(UpdateCredentialCommand request, CancellationToken cancellationToken)
        {
            var entity = await _dbContext.Credentials.FirstOrDefaultAsync(u => u.Username == request.Username, cancellationToken);

            if (entity == null || entity.Username != request.Username) throw new NotFoundException(nameof(Credential), request.Username);

            entity.Username = request.Username;

            await _dbContext.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
