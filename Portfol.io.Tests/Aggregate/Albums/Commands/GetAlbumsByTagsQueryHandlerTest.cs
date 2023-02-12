using AutoMapper;
using Portfol.io.Application.Aggregate.Albums.DTO;
using Portfol.io.Application.Aggregate.Albums.Queries.GetAlbumsByTags;
using Portfol.io.Application.Common.Exceptions;
using Portfol.io.Persistence;
using Portfol.io.Tests.Common;
using Shouldly;
using Xunit;

namespace Portfol.io.Tests.Aggregate.Albums.Commands
{
    [Collection(nameof(QueryCollection))]
    public class GetAlbumsByTagsQueryHandlerTest
    {
        private readonly PortfolioDbContext Context;
        private readonly IMapper Mapper;

        public GetAlbumsByTagsQueryHandlerTest(QueryTestFixture fixture)
        {
            Context = fixture.Context;
            Mapper = fixture.Mapper;
        }

        [Fact]
        public async Task GetAlbumsByTagsQueryHandlerTest_Success()
        {
            //Arrange
            var handler = new GetAlbumsByTagsQueryHandler(Context, Mapper);

            //Act
            var result = await handler.Handle(
                new GetAlbumsByTagsQuery
                {
                    TagIds = new List<Guid>
                    {
                        PortfolioContextFactory.Tag1,
                        PortfolioContextFactory.Tag2,
                        PortfolioContextFactory.Tag3,
                    }
                }, CancellationToken.None);

            //Assert
            result.ShouldBeOfType(typeof(GetAlbumsDto));
            result.Albums.Count().ShouldBe(5);
        }

        [Fact]
        public async Task GetAlbumsByTagsQueryHandlerTest_FailOnWrong()
        {
            //Arrange
            var handler = new GetAlbumsByTagsQueryHandler(Context, Mapper);

            //Act
            //Assert
            await Assert.ThrowsAsync<NotFoundException>(async () =>
            {
                await handler.Handle(
                    new GetAlbumsByTagsQuery
                    {
                        TagIds = new List<Guid>
                        {
                            Guid.NewGuid()
                        }
                    }, CancellationToken.None);
            });
        }
    }
}
