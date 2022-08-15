using MediatR;
using Microsoft.EntityFrameworkCore;
using Portfol.io.Application.Common.Exceptions;
using Portfol.io.Application.Common.Services.Cryption;
using Portfol.io.Application.Interfaces;
using Portfol.io.Domain;

namespace Portfol.io.Application.Aggregate.Credentials.Commands.RemoveCredential
{
    public class RemoveCredentialCommandHandler : IRequestHandler<RemoveCredentialCommand, Unit>
    {
        private readonly IPortfolioDbContext _dbContext;

        public RemoveCredentialCommandHandler(IPortfolioDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Unit> Handle(RemoveCredentialCommand request, CancellationToken cancellationToken)
        {
            var entity = await _dbContext.Credentials.FirstOrDefaultAsync(u => u.Username == request.Username, cancellationToken);

            if (entity == null || entity.Username != request.Username) throw new NotFoundException(nameof(Credential), request.Username);

            if (!PassCryptionFactory.PassCryption().Verify(request.Password, entity.Password)) throw new WrongException(nameof(request.Password));

            _dbContext.Credentials.Remove(entity);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
