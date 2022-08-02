using MediatR;
using Portfol.io.Application.Common.Exceptions;
using Portfol.io.Application.Common.Services.Cryption;
using Portfol.io.Application.Interfaces;
using Portfol.io.Domain;

namespace Portfol.io.Application.Aggregate.Credentials.Commands.CreateCredential
{
    public class CreateCredentialCommandHandler : IRequestHandler<CreateCredentialCommand, string>
    {
        private readonly IPortfolioDbContext _dbContext;

        public CreateCredentialCommandHandler(IPortfolioDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<string> Handle(CreateCredentialCommand request, CancellationToken cancellationToken)
        {
            if (request.Password != request.ConfirmPassword) throw new PassDontMatchException();

            var credential = new Credential
            {
                Username = request.Username,
                Password = PassCryptionFactory.PassCryption().Encrypt(request.Password)
            };

            await _dbContext.Credentials.AddAsync(credential);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return credential.Username;
        }
    }
}
