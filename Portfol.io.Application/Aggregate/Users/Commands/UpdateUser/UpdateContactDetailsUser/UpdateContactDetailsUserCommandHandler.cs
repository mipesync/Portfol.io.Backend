using AutoMapper;
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
        private readonly IMapper _mapper;

        public UpdateContactDetailsUserCommandHandler(IPortfolioDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(UpdateContactDetailsUserCommand request, CancellationToken cancellationToken)
        {
            var entity = await _dbContext.Users.FirstOrDefaultAsync(u => u.Id == request.Model.Id, cancellationToken);

            if (entity == null || entity.Id != request.Model.Id) throw new NotFoundException(nameof(User), request.Model.Id);

            if (entity.VerifyCode != request.Model.VerifyCode || entity.VerifyCode is null) throw new WrongException(nameof(request.Model.VerifyCode));

            entity.Email = request.Model.Email;
            entity.Phone = request.Model.Phone;
            entity.VerifyCode = null;

            await _dbContext.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
