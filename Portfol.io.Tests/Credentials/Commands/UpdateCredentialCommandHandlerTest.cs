using Microsoft.EntityFrameworkCore;
using Portfol.io.Application.Aggregate.Credentials.Commands.UpdateCredential;
using Portfol.io.Application.Common.Exceptions;
using Portfol.io.Tests.Common;
using Xunit;

namespace Portfol.io.Tests.Credentials.Commands
{
    public class UpdateCredentialCommandHandlerTest : TestCommandBase
    {
        [Fact]
        public async Task UpdateCredentialCommandHandlerTest_Success()
        {
            //Arrange
            var handler = new UpdateCredentialCommandHandler(Context);
            var newUsername = "NewUsername";
            var oldUsername = "guestos";

            //Act
            await handler.Handle(
                new UpdateCredentialCommand
                {
                    Model = new UpdateCredentialViewModel
                    {
                        OldUsername = oldUsername,
                        NewUsername = newUsername,
                        VerifyCode = "123456"
                    }
                }, CancellationToken.None);

            //Assert
            Assert.NotNull(await Context.Credentials.FirstOrDefaultAsync(u => u.Username == newUsername));
        }

        [Fact]
        public async Task UpdateCredentialCommandHandlerTest_FailOnWrongUsername()
        {
            //Arrange
            var handler = new UpdateCredentialCommandHandler(Context);
            var newUsername = "NewUsername";
            var oldUsername = "wrong";

            //Act
            //Assert
            await Assert.ThrowsAsync<NotFoundException>(async () =>
            {
                await handler.Handle(
                    new UpdateCredentialCommand
                    {
                        Model = new UpdateCredentialViewModel
                        {
                            OldUsername = oldUsername,
                            NewUsername = newUsername,
                            VerifyCode = "123456"
                        }
                    }, CancellationToken.None);
            });
        }

        [Fact]
        public async Task UpdateCredentialCommandHandlerTest_FailOnWrongVerifyCode()
        {
            //Arrange
            var handler = new UpdateCredentialCommandHandler(Context);

            //Act
            //Assert
            await Assert.ThrowsAsync<WrongException>(async () =>
            {
                await handler.Handle(
                    new UpdateCredentialCommand
                    {
                        Model = new UpdateCredentialViewModel
                        {
                            OldUsername = "guestos",
                            NewUsername = "guestos_new",
                            VerifyCode = "wrong_verify_code"
                        }
                    }, CancellationToken.None);
            });
        }
    }
}
