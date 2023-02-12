using AutoMapper;
using Portfol.io.Application.Aggregate.Albums.DTO;
using Portfol.io.Application.Aggregate.Albums.Queries.GetAlbumsByUserId;
using Portfol.io.Application.Common.Exceptions;
using Portfol.io.Persistence;
using Portfol.io.Tests.Common;
using Shouldly;
using Xunit;

namespace Portfol.io.Tests.Aggregate.Albums.Queries
{
    [Collection(nameof(QueryCollection))]
    public class GetAlbumsByUserIdQueryHandlerTest
    {
        private readonly PortfolioDbContext Context;
        private readonly IMapper Mapper;

        public GetAlbumsByUserIdQueryHandlerTest(QueryTestFixture fixture)
        {
            Context = fixture.Context;
            Mapper = fixture.Mapper;
        }

        [Fact]
        public async Task GetAlbumsByUserIdQueryHandlerTest_Success()
        {
            //Arrange
            var handler = new GetAlbumsByUserIdQueryHandler(Mapper, Context);

            //Act
            var result = await handler.Handle(
                new GetAlbumsByUserIdQuery
                {
                    UserId = PortfolioContextFactory.UserAId
                }, CancellationToken.None);

            //Assert
            result.ShouldBeOfType(typeof(GetAlbumsDto));
            result.Albums.Count().ShouldBe(2);
        }

        [Fact]
        public async Task GetAlbumsByUserIdQueryHandlerTest_FailOnWrongUserIdOrAlbumsNotExists()
        {
            //Arrange
            var handler = new GetAlbumsByUserIdQueryHandler(Mapper, Context);

            //Act
            //Assert
            await Assert.ThrowsAsync<NotFoundException>(async () =>
            {
                await handler.Handle(
                    new GetAlbumsByUserIdQuery
                    {
                        UserId = Guid.NewGuid()
                    }, CancellationToken.None);
            });
        }
    }
}
