using MediatR;
using Microsoft.EntityFrameworkCore;
using Portfol.io.Application.Common.Exceptions;
using Portfol.io.Application.Interfaces;
using Portfol.io.Domain;

namespace Portfol.io.Application.Aggregate.Users.Commands.UpdateUser.UpdateContactDetailsUser
{
    public class UpdateContactDetailsUserCommandHandler : IRequestHandler<UpdateContactDetailsUserCommand, Unit>
    {
        private readonly IPortfolioDbContext _dbContext;

        public UpdateContactDetailsUserCommandHandler(IPortfolioDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Unit> Handle(UpdateContactDetailsUserCommand request, CancellationToken cancellationToken)
        {
            var entity = await _dbContext.Users.FirstOrDefaultAsync(u => u.Id == request.Id, cancellationToken);

            if (entity == null || entity.Id != request.Id) throw new NotFoundException(nameof(User), request.Id);

            if (entity.VerifyCode != request.VerifyCode || entity.VerifyCode is null) throw new WrongException(nameof(request.VerifyCode));

            entity.Email = request.Email;
            entity.Phone = request.Phone;
            entity.VerifyCode = null;

            await _dbContext.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
