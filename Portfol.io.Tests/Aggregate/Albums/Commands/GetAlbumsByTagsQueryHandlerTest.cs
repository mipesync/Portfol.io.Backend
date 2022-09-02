using AutoMapper;
using Portfol.io.Application.Aggregate.Albums.Queries.GetAlbumsByTags;
using Portfol.io.Application.Common.Exceptions;
using Portfol.io.Domain;
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
                    Tags = new List<Tag>
                    {
                        new Tag
                        {
                            Id = PortfolioContextFactory.Tag1,
                            Name = "Тег 1"
                        },
                        new Tag
                        {
                            Id = PortfolioContextFactory.Tag2,
                            Name = "Тег 2"
                        },
                        new Tag
                        {
                            Id = PortfolioContextFactory.Tag3,
                            Name = "Тег 3"
                        }
                    }
                }, CancellationToken.None);

            //Assert
            result.ShouldBeOfType(typeof(AlbumsViewModel));
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
                        Tags = new List<Tag>
                        {
                            new Tag
                            {
                                Id = Guid.Empty,
                                Name = "tag_0"
                            }
                        }
                    }, CancellationToken.None);
            });
        }
    }
}
