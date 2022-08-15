using AutoMapper;
using Portfol.io.Application.Aggregate.Users.Queries.GetUserInfoById;
using Portfol.io.Application.Common.Exceptions;
using Portfol.io.Persistence;
using Portfol.io.Tests.Common;
using Shouldly;
using Xunit;

namespace Portfol.io.Tests.Aggregate.Users.Queries
{
    [Collection(nameof(QueryCollection))]
    public class GetUserInfoByIdQueryHandlerTest
    {
        private readonly PortfolioDbContext Context;
        private readonly IMapper Mapper;

        public GetUserInfoByIdQueryHandlerTest(QueryTestFixture fixture)
        {
            Context = fixture.Context;
            Mapper = fixture.Mapper;
        }

        [Fact]
        public async Task GetUserInfoByIdQueryHandler_Success()
        {
            //Arrange
            var handler = new GetUserInfoByIdQueryHandler(Context, Mapper);
            var userId = PortfolioContextFactory.UserAId;

            //Act
            var result = await handler.Handle(
                new GetUserInfoByIdQuery { UserId = userId }, CancellationToken.None);

            //Assert
            result.ShouldBeOfType<UserDetailsViewModel>();
            result.Id.ShouldBe(userId);
        }

        [Fact]
        public async Task GetUserInfoByIdQueryHandler_FailOnWrongUserId()
        {
            //Arrange
            var handler = new GetUserInfoByIdQueryHandler(Context, Mapper);

            //Act
            //Assert
            await Assert.ThrowsAsync<NotFoundException>(async () =>
            {
                await handler.Handle(
                    new GetUserInfoByIdQuery { UserId = Guid.NewGuid() }, CancellationToken.None);
            });
        }
    }
}
