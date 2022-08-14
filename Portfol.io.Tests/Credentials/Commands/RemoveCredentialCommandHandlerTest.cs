using Microsoft.EntityFrameworkCore;
using Portfol.io.Application.Aggregate.Credentials.Commands.RemoveCredential;
using Portfol.io.Application.Common.Exceptions;
using Portfol.io.Tests.Common;
using Xunit;

namespace Portfol.io.Tests.Credentials.Commands
{
    public class RemoveCredentialCommandHandlerTest : TestCommandBase
    {
        [Fact]
        public async Task RemoveCredentialCommandHandler_Success()
        {
            //Arrange - Подготовка данных для теста
            var handler = new RemoveCredentialCommandHandler(Context);

            //Act - Высполнение логики
            var handleResponse = await handler.Handle(
                new RemoveCredentialCommand
                {
                    Model = new RemoveCredentialViewModel
                    {
                        Username = "guestos",
                        Password = "guestos",
                        VerifyCode = "123456"
                    }
                }, CancellationToken.None);

            //Assert - Проверка результатов
            Assert.Null(
                await Context.Credentials.FirstOrDefaultAsync(u => u.Username == "guestos"));
        }

        [Fact]
        public async Task RemoveCredentialCommandHandler_FailOnWrongUsername()
        {
            //Arrange
            var handler = new RemoveCredentialCommandHandler(Context);

            //Act
            //Assert
            await Assert.ThrowsAsync<NotFoundException>(async () =>
            {
                await handler.Handle(
                    new RemoveCredentialCommand
                    {
                        Model = new RemoveCredentialViewModel
                        {
                            Username = "wrong_username",
                            Password = "123123",
                            VerifyCode = "123456"
                        }
                    }, CancellationToken.None);
            });
        }

        [Fact]
        public async Task RemoveCredentialCommandHandler_FailOnWrongVerifyCode()
        {
            //Arrange
            var handler = new RemoveCredentialCommandHandler(Context);

            //Act
            //Assert
            await Assert.ThrowsAsync<WrongException>(async () =>
            {
                await handler.Handle(
                    new RemoveCredentialCommand
                    {
                        Model = new RemoveCredentialViewModel
                        {
                            Username = "guestos",
                            Password = "123123",
                            VerifyCode = "wrong_verify_code"
                        }
                    }, CancellationToken.None);
            });
        }
    }
}
