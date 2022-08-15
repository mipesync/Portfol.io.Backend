using Microsoft.EntityFrameworkCore;
using Portfol.io.Application.Aggregate.Users.Commands.UpdateUser;
using Portfol.io.Application.Common.Exceptions;
using Portfol.io.Tests.Common;
using Shouldly;
using Xunit;

namespace Portfol.io.Tests.Aggregate.Users.Commands
{
    public class UpdateUserCommandHandlerTest : TestCommandBase
    {
        [Fact]
        public async Task UpdateUserCommandHandlerTest_Success()
        {
            //Arrange
            var handler = new UpdateUserCommandHandler(Context);
            var newName = "Some Name";

            //Act
            await handler.Handle(
                new UpdateUserCommand
                {
                    Id = PortfolioContextFactory.UserAId,
                    Name = newName,
                    Description = "Some desc..."
                }, CancellationToken.None);

            //Assert
            var result = await Context.Users.FirstOrDefaultAsync(u => u.Id == PortfolioContextFactory.UserAId, CancellationToken.None);
            result!.Name.ShouldBe(newName);
        }

        [Fact]
        public async Task UpdateContactDetailsUserCommandHandlerTest_FailOnWrongUserId()
        {
            //Arrange
            var handler = new UpdateUserCommandHandler(Context);

            //Act
            //Assert
            await Assert.ThrowsAsync<NotFoundException>(async () =>
            {
                await handler.Handle(
                new UpdateUserCommand
                {
                    Id = Guid.NewGuid(),
                    Name = "Some Name",
                    Description = "Some desc..."
                }, CancellationToken.None);
            });
        }
    }
}
