using MediatR;
using Microsoft.EntityFrameworkCore;
using Portfol.io.Application.Common.Exceptions;
using Portfol.io.Application.Common.Services.Cryption;
using Portfol.io.Application.Interfaces;
using Portfol.io.Domain;

namespace Portfol.io.Application.Aggregate.Credentials.Commands.UpdateCredential.ResetPassword
{
    public class ResetPasswordCommandHandler : IRequestHandler<ResetPasswordCommand, Unit>
    {
        private readonly IPortfolioDbContext _dbContext;

        public ResetPasswordCommandHandler(IPortfolioDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Unit> Handle(ResetPasswordCommand request, CancellationToken cancellationToken)
        {
            var entity = await _dbContext.Credentials.Include(u => u.User).FirstOrDefaultAsync(u => u.Username == request.Username, cancellationToken);

            if (entity == null || entity.Username != request.Username) throw new NotFoundException(nameof(Credential), request.Username);

            if (entity.User == null || entity.User.CredentialsId != entity.Id) throw new NotFoundException(nameof(User), entity.Id);

            if (request.ConfirmNewPassword != request.NewPassword)
                throw new DoesNotMatchException(nameof(request.ConfirmNewPassword), nameof(request.NewPassword));

            if (request.VerifyCode != entity.User.VerifyCode || entity.User.VerifyCode is null) throw new WrongException(nameof(request.VerifyCode));

            entity.Password = PassCryptionFactory.PassCryption().Encrypt(request.NewPassword);
            entity.User.VerifyCode = null;

            await _dbContext.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
