using Microsoft.EntityFrameworkCore;
using Portfol.io.Application.Aggregate.Users.Commands.CreateUser;
using Portfol.io.Application.Common.Exceptions;
using Portfol.io.Tests.Common;
using Xunit;

namespace Portfol.io.Tests.Aggregate.Users.Commands
{
    public class CreateUserCommandHandlerTest : TestCommandBase
    {
        [Fact]
        public async Task CreateUserCommandHandlerTest_Success()
        {
            //Arrange
            var handler = new CreateUserCommandHandler(Context);

            //Act
            var result = await handler.Handle(
                new CreateUserCommand
                {
                    Name = "Some Name",
                    Description = "Some desc...",
                    DateOfBirth = DateOnly.Parse("07.01.2003"),
                    Email = "asd@asd.asd",
                    CredentialsId = 1,
                    RoleId = 2
                }, CancellationToken.None);

            //Assert
            Assert.NotNull(await Context.Users.FirstOrDefaultAsync(u => u.Id == result));
        }

        [Fact]
        public async Task CreateUserCommandHandlerTest_FailOnUserAlreadyExists()
        {
            //Arrange
            var handler = new CreateUserCommandHandler(Context);

            //Act
            //Assert
            await Assert.ThrowsAsync<AlreadyExistsException>(async () =>
            {
                await handler.Handle(
                new CreateUserCommand
                {
                    Name = "Some Name",
                    Description = "Some desc...",
                    DateOfBirth = DateOnly.Parse("07.01.2003"),
                    Email = "guestos@aaa.moc",
                    CredentialsId = 1,
                    RoleId = 2
                }, CancellationToken.None);
            });
        }
    }
}
