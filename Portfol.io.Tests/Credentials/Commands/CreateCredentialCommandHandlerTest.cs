using Microsoft.EntityFrameworkCore;
using Portfol.io.Application.Aggregate.Credentials.Commands.CreateCredential;
using Portfol.io.Application.Common.Exceptions;
using Portfol.io.Tests.Common;
using Xunit;

namespace Portfol.io.Tests.Credentials.Commands
{
    public class CreateCredentialCommandHandlerTest : TestCommandBase
    {
        [Fact]
        public async Task CreateCredentialCommandHandler_Success()
        {
            //Arrange - Подготовка данных для теста
            var handler = new CreateCredentialCommandHandler(Context);
            var username = "some_username";
            var password = "adminous";

            //Act - Выполнение логики
            var handleResponse = await handler.Handle(
                new CreateCredentialCommand
                {
                    Model = new CreateCredentialViewModel
                    {
                        Username = username,
                        Password = password,
                        ConfirmPassword = password
                    }
                }, CancellationToken.None);

            //Assert - Проверка результатов
            Assert.NotNull(
                await Context.Credentials.FirstOrDefaultAsync(u => u.Username == handleResponse));
        }

        [Fact]
        public async Task CreateCredentialCommandHandler_FailOnWrongConfirmPassword()
        {
            //Arrange
            var handler = new CreateCredentialCommandHandler(Context);

            //Act
            //Assert
            await Assert.ThrowsAsync<DoesNotMatchException>(async () =>
            {
                await handler.Handle(
                    new CreateCredentialCommand
                    {
                        Model = new CreateCredentialViewModel
                        {
                            Username = "username",
                            Password = "123123123",
                            ConfirmPassword = "12121212"
                        }
                    }, CancellationToken.None);
            });
        }

        [Fact]
        public async Task CreateCredentialCommandHandler_FailOnAlreadyExists()
        {
            //Arrange
            var handler = new CreateCredentialCommandHandler(Context);

            //Act
            //Assert
            await Assert.ThrowsAsync<Exception>(async () =>
            {
                await handler.Handle(
                    new CreateCredentialCommand
                    {
                        Model = new CreateCredentialViewModel
                        {
                            Username = "guestos",
                            Password = "123123123",
                            ConfirmPassword = "12121212"
                        }
                    }, CancellationToken.None);
            });
        }
    }
}
