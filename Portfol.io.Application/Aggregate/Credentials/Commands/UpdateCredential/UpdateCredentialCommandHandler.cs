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
            var entity = await _dbContext.Credentials.Include(u => u.User!).FirstOrDefaultAsync(u => u.Username == request.OldUsername, cancellationToken);

            if (entity == null || entity.Username != request.OldUsername) throw new NotFoundException(nameof(Credential), request.OldUsername);

            if (entity.User!.VerifyCode != request.VerifyCode || entity.User.VerifyCode is null) throw new WrongException(nameof(request.VerifyCode));

            entity.Username = request.NewUsername;
            entity.User.VerifyCode = null!;

            await _dbContext.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
