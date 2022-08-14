using AutoMapper;
using Portfol.io.Application.Aggregate.Credentials.Queries.GetCredentialByUsername;
using Portfol.io.Application.Common.Exceptions;
using Portfol.io.Application.Common.Services.Cryption;
using Portfol.io.Persistence;
using Portfol.io.Tests.Common;
using Shouldly;
using Xunit;

namespace Portfol.io.Tests.Credentials.Query
{
    [Collection(nameof(QueryCollection))]
    public class GetCredentialByUsernameQueryHandlerTest
    {
        private readonly PortfolioDbContext Context;
        private readonly IMapper Mapper;

        public GetCredentialByUsernameQueryHandlerTest(QueryTestFixture fixture)
        {
            Context = fixture.Context;
            Mapper = fixture.Mapper;
        }

        [Fact]
        public async Task GetCredentialByUsernameQueryHandlerTest_Success()
        {
            //Arrange
            var handler = new GetCredentialByUsernameQueryHandler(Mapper, Context);
            var username = "guestos";
            var password = "guestos";
            var passHash = PortfolioContextFactory.UserAPassHash;

            //Act
            var result = await handler.Handle(new GetCredentialByUsernameQuery { Username = username }, CancellationToken.None);

            //Assert
            result.ShouldBeOfType<CredentialUsernameViewModel>();
            result.Id.ShouldBe(1);
            result.Username.ShouldBe(username);
            result.Password.ShouldBe(passHash);
            PassCryptionFactory.PassCryption().Verify(password, passHash).ShouldBe(true);
        }

        [Fact]
        public async Task GetCredentialByUsernameQueryHandlerTest_FailOnWrongUsername()
        {
            //Arrange
            var handler = new GetCredentialByUsernameQueryHandler(Mapper, Context);

            //Act
            //Assert
            await Assert.ThrowsAsync<NotFoundException>(async () =>
            {
                await handler.Handle(
                    new GetCredentialByUsernameQuery
                    {
                        Username = "wrong_username"
                    }, CancellationToken.None);
            });
        }
    }
}
