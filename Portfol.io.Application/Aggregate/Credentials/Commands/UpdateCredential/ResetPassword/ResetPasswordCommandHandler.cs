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
            var entity = await _dbContext.Credentials.Include(u => u.User).FirstOrDefaultAsync(u => u.Username == request.Model.Username, cancellationToken);

            if (entity == null || entity.Username != request.Model.Username) throw new NotFoundException(nameof(Credential), request.Model.Username);

            if (entity!.User == null || entity.User.CredentialsId != entity.Id) throw new NotFoundException(nameof(User), entity.Id);

            if (request.Model.ConfirmNewPassword != request.Model.NewPassword)
                throw new DoesNotMatchException(nameof(request.Model.ConfirmNewPassword), nameof(request.Model.NewPassword));

            if (request.Model.VerifyCode != entity.User.VerifyCode || entity.User.VerifyCode is null) throw new WrongException(nameof(request.Model.VerifyCode));

            entity.Password = PassCryptionFactory.PassCryption().Encrypt(request.Model.NewPassword);
            entity.User.VerifyCode = null;

            await _dbContext.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
