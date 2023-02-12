using AutoMapper;
using Portfol.io.Application.Aggregate.Albums.DTO;
using Portfol.io.Application.Aggregate.Albums.Queries.GetAllAlbums;
using Portfol.io.Persistence;
using Portfol.io.Tests.Common;
using Shouldly;
using Xunit;

namespace Portfol.io.Tests.Aggregate.Albums.Queries
{
    [Collection(nameof(QueryCollection))]
    public class GetAllAlbumQueryHandlerTest
    {
        private readonly PortfolioDbContext Context;
        private readonly IMapper Mapper;

        public GetAllAlbumQueryHandlerTest(QueryTestFixture fixture)
        {
            Context = fixture.Context;
            Mapper = fixture.Mapper;
        }

        [Fact]
        public async Task GetAllAlbumQueryHandlerTest_Success()
        {
            //Arrange
            var handler = new GetAllAlbumsQueryHandler(Context, Mapper);

            //Act
            var result = await handler.Handle(new GetAllAlbumsQuery(), CancellationToken.None);

            //Assert
            result.ShouldBeOfType<GetAlbumsDto>();
            result.Albums.Count().ShouldBe(4);
        }
    }
}
