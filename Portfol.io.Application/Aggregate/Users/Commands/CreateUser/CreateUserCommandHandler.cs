using MediatR;
using Microsoft.EntityFrameworkCore;
using Portfol.io.Application.Common.Exceptions;
using Portfol.io.Application.Interfaces;
using Portfol.io.Domain;

namespace Portfol.io.Application.Aggregate.Users.Commands.CreateUser
{
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, Guid>
    {
        private readonly IPortfolioDbContext _dbContext;

        public CreateUserCommandHandler(IPortfolioDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Guid> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            var entity = await _dbContext.Users.FirstOrDefaultAsync(u => u.Email == request.Email, cancellationToken);

            if (entity is not null) throw new AlreadyExistsException(nameof(User), request.Email);

            var user = new User
            {
                Id = Guid.NewGuid(),
                Name = request.Name,
                Description = request.Description,
                ProfileImagePath = "/ProfileImages/default.png",
                DateOfBirth = request.DateOfBirth,
                DateOfCreation = DateTime.Now,
                Phone = request.Phone,
                Email = request.Email,
                CredentialsId = request.CredentialsId,
                RoleId = request.RoleId
            };

            await _dbContext.Users.AddAsync(user);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return user.Id;
        }
    }
}
