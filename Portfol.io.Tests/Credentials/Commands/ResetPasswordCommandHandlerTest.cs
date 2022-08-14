using Microsoft.EntityFrameworkCore;
using Portfol.io.Application.Aggregate.Credentials.Commands.UpdateCredential.ResetPassword;
using Portfol.io.Application.Common.Exceptions;
using Portfol.io.Application.Common.Services.Cryption;
using Portfol.io.Tests.Common;
using Shouldly;
using Xunit;

namespace Portfol.io.Tests.Credentials.Commands
{
    public class ResetPasswordCommandHandlerTest : TestCommandBase
    {
        [Fact]
        public async Task ResetPasswordCommandHandlerTest_Success()
        {
            //Arrange
            var handler = new ResetPasswordCommandHandler(Context);
            var username = "guestos";
            var newPassword = "guestos_new";

            //Act
            await handler.Handle(
                new ResetPasswordCommand
                {
                    Model = new ResetPasswordViewModel
                    {
                        Username = username,
                        NewPassword = newPassword,
                        ConfirmNewPassword = newPassword,
                        VerifyCode = "123456"
                    }
                }, CancellationToken.None);

            //Assert
            var result = await Context.Credentials.FirstOrDefaultAsync(u => u.Username == username, CancellationToken.None);
            PassCryptionFactory.PassCryption().Verify(newPassword, result!.Password).ShouldBe(true);
        }

        [Fact]
        public async Task ResetPasswordCommandHandlerTest_FailOnWrongUsername()
        {
            //Arrange
            var handler = new ResetPasswordCommandHandler(Context);
            var newPassword = "guestos_new";

            //Act
            //Assert
            await Assert.ThrowsAsync<NotFoundException>(async () =>
            {
                await handler.Handle(
                    new ResetPasswordCommand
                    {
                        Model = new ResetPasswordViewModel
                        {
                            Username = "Wrong_Username",
                            NewPassword = newPassword,
                            ConfirmNewPassword = newPassword,
                            VerifyCode = "123456"
                        }
                    }, CancellationToken.None);
            });
        }

        [Fact]
        public async Task ResetPasswordCommandHandlerTest_FailOnUserNotExists()
        {
            //Arrange
            var handler = new ResetPasswordCommandHandler(Context);

            //Act
            //Assert
            await Assert.ThrowsAsync<DoesNotMatchException>(async () =>
            {
                await handler.Handle(
                    new ResetPasswordCommand
                    {
                        Model = new ResetPasswordViewModel
                        {
                            Username = "guestos",
                            NewPassword = "pass1",
                            ConfirmNewPassword = "pass2",
                            VerifyCode = "123456"
                        }
                    }, CancellationToken.None);
            });
        }

        [Fact]
        public async Task ResetPasswordCommandHandlerTest_FailOnWrongVerifyCode()
        {
            //Arrange
            var handler = new ResetPasswordCommandHandler(Context);
            var newPassword = "guestos_new";

            //Act
            //Assert
            await Assert.ThrowsAsync<WrongException>(async () =>
            {
                await handler.Handle(
                    new ResetPasswordCommand
                    {
                        Model = new ResetPasswordViewModel
                        {
                            Username = "guestos",
                            NewPassword = newPassword,
                            ConfirmNewPassword = newPassword,
                            VerifyCode = "wrong_verify_code"
                        }
                    }, CancellationToken.None);
            });
        }
    }
}
