using AutoMapper;
using Microsoft.Extensions.Configuration;
using Portfol.io.Application.Aggregate.Albums.DTO;
using Portfol.io.Application.Aggregate.Albums.Queries.GetAlbumById;
using Portfol.io.Application.Common.Exceptions;
using Portfol.io.Persistence;
using Portfol.io.Tests.Common;
using Shouldly;
using Xunit;

namespace Portfol.io.Tests.Aggregate.Albums.Queries
{
    [Collection(nameof(QueryCollection))]
    public class GetAlbumByIdQueryHandlerTest
    {
        private readonly PortfolioDbContext Context;
        private readonly IMapper Mapper;
        private readonly IConfiguration Config;

        public GetAlbumByIdQueryHandlerTest(QueryTestFixture fixture, IConfiguration config)
        {
            Context = fixture.Context;
            Mapper = fixture.Mapper;
            Config = config;
        }

        [Fact]
        public async Task GetAlbumByIdQueryHandlerTest_Success()
        {
            //Arrange
            var handler = new GetAlbumByIdQueryHandler(Context, Mapper, Config);

            //Act
            var result = await handler.Handle(
                new GetAlbumByIdQuery
                {
                    Id = PortfolioContextFactory.Album1
                }, CancellationToken.None);

            //Assert
            result.ShouldBeOfType(typeof(GetAlbumByIdDto));
        }

        [Fact]
        public async Task GetAlbumByIdQueryHandlerTest_FailOnWrongId()
        {
            //Arrange
            var handler = new GetAlbumByIdQueryHandler(Context, Mapper, Config);

            //Act
            //Assert
            await Assert.ThrowsAsync<NotFoundException>(async () =>
            {
                await handler.Handle(
                    new GetAlbumByIdQuery
                    {
                        Id = Guid.Empty
                    }, CancellationToken.None);
            });
        }
    }
}
