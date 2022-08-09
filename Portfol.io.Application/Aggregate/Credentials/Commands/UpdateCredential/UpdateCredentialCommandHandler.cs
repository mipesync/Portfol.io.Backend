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
            var entity = await _dbContext.Credentials.Include(u => u.User!.VerifyCode).FirstOrDefaultAsync(u => u.Username == request.Model.OldUsername, cancellationToken);

            if (entity == null || entity.Username != request.Model.OldUsername) throw new NotFoundException(nameof(Credential), request.Model.OldUsername);

            if (entity.User!.VerifyCode != request.Model.VerifyCode || entity.User.VerifyCode is null) throw new WrongException(nameof(request.Model.VerifyCode));

            entity.Username = request.Model.NewUsername;
            entity.User.VerifyCode = null!;

            await _dbContext.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
