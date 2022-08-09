﻿using MediatR;
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
            if (request.Model.Password != request.Model.ConfirmPassword) throw new DoesNotMatchException(nameof(request.Model.Password), nameof(request.Model.ConfirmPassword));

            var credential = new Credential
            {
                Username = request.Model.Username,
                Password = PassCryptionFactory.PassCryption().Encrypt(request.Model.Password)
            };

            await _dbContext.Credentials.AddAsync(credential);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return credential.Username;
        }
    }
}
