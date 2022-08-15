using Microsoft.EntityFrameworkCore;
using Portfol.io.Application.Aggregate.Users.Commands.UpdateUser.UpdateContactDetailsUser;
using Portfol.io.Application.Common.Exceptions;
using Portfol.io.Tests.Common;
using Shouldly;
using Xunit;

namespace Portfol.io.Tests.Aggregate.Users.Commands
{
    public class UpdateContactDetailsUserCommandHandlerTest : TestCommandBase
    {
        [Fact]
        public async Task UpdateContactDetailsUserCommandHandlerTest_Success()
        {
            //Arrange
            var handler = new UpdateContactDetailsUserCommandHandler(Context);
            var newEmail = "asd@asd.asd";

            //Act
            await handler.Handle(
                new UpdateContactDetailsUserCommand
                {
                    Id = PortfolioContextFactory.UserAId,
                    Email = newEmail,
                    VerifyCode = "123456"
                }, CancellationToken.None);

            //Assert
            var result = await Context.Users.FirstOrDefaultAsync(u => u.Id == PortfolioContextFactory.UserAId, CancellationToken.None);
            result!.Email.ShouldBe(newEmail);
        }

        [Fact]
        public async Task UpdateContactDetailsUserCommandHandlerTest_FailOnWrongUserId()
        {
            //Arrange
            var handler = new UpdateContactDetailsUserCommandHandler(Context);

            //Act
            //Assert
            await Assert.ThrowsAsync<NotFoundException>(async () =>
            {
                await handler.Handle(
                new UpdateContactDetailsUserCommand
                {
                    Id = Guid.NewGuid(),
                    Email = "asd@asd.asd",
                    VerifyCode = "123456"
                }, CancellationToken.None);
            });
        }
    }
}
