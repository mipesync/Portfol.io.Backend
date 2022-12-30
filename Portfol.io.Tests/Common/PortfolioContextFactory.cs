using Microsoft.EntityFrameworkCore;
using Portfol.io.Domain;
using Portfol.io.Persistence;

namespace Portfol.io.Tests.Common
{
    public class PortfolioContextFactory
    {
        public static Guid UserAId = Guid.Parse("0B7784DC-2A9A-45B9-B62B-74D2F3BA0A37");
        public static Guid UserBId = Guid.Parse("4093ADD3-21F8-4069-BE01-38D1E031A997");

        public static Guid Album1 = Guid.Parse("1C95B736-2160-459B-8C28-1CD35847534B");
        public static Guid Album2 = Guid.Parse("93A4CF12-8D60-47D7-B484-81F6B6BBA2B8");
        public static Guid Album3 = Guid.Parse("98474E54-79DD-4DF7-BAE8-5B9E58FEDAB2");
        public static Guid Album4 = Guid.Parse("E68C0092-CB4B-45E0-A47D-7579127444A9");

        public static Guid Tag1 = Guid.Parse("57F499E3-3276-4F26-BB4D-5FEC016F52E4");
        public static Guid Tag2 = Guid.Parse("3FB04FCC-7A7B-487D-9254-BF9F3DFE351F");
        public static Guid Tag3 = Guid.Parse("A0CB93E0-E328-4B15-990A-4A668DD345DA");
        public static Guid Tag4 = Guid.Parse("C1A64F77-5B7E-4E6F-BBED-8E70F3C38F92");
        public static Guid Tag5 = Guid.Parse("5D2506C3-F6F6-4CA0-A098-0F99FF1649F0");

        public static Guid Photo1 = Guid.Parse("FC5ABAEF-F8A4-4D87-85B2-B2C7CAD6ACA7");
        public static Guid Photo2 = Guid.Parse("0A0B7741-9260-42BB-8094-C18F5B968C3F");
        public static Guid Photo3 = Guid.Parse("0A2680E7-A1F6-4654-A716-8A8B91E81228");
        public static Guid Photo4 = Guid.Parse("0A90EF14-46BF-44E7-BC23-A82DB2389135");
        public static Guid Photo5 = Guid.Parse("115BA80B-DACF-4A4A-A4D3-9B840C305BF2");

        public static PortfolioDbContext Create()
        {
            var options = new DbContextOptionsBuilder<PortfolioDbContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;

            var context = new PortfolioDbContext(options);
            context.Database.EnsureCreated();

            context.Albums.AddRange(
                new Album
                {
                    Id = Album1,
                    Name = "Альбом Гуеста 1",
                    CreationDate = DateTime.Now,
                    UserId = UserAId
                },
                new Album
                {
                    Id = Album2,
                    Name = "Альбом Гуеста 2",
                    CreationDate = DateTime.Now,
                    UserId = UserAId
                },
                new Album
                {
                    Id = Album3,
                    Name = "Альбом Админоса 1",
                    CreationDate = DateTime.Now,
                    UserId = UserBId
                },
                new Album
                {
                    Id = Album4,
                    Name = "Альбом Админоса 2",
                    CreationDate = DateTime.Now,
                    UserId = UserBId
                });

            context.Photos.AddRange(
                new Photo
                {
                    Id = Photo1,
                    Path = "some_url",
                    AlbumId = Album1
                },
                new Photo
                {
                    Id = Photo2,
                    Path = "some_url",
                    AlbumId = Album1
                },
                new Photo
                {
                    Id = Photo3,
                    Path = "some_url",
                    AlbumId = Album1
                },
                new Photo
                {
                    Id = Photo4,
                    Path = "some_url",
                    AlbumId = Album2
                },
                new Photo
                {
                    Id = Photo5,
                    Path = "some_url",
                    AlbumId = Album2
                });

            context.AlbumTags.AddRange(
                new AlbumTag
                {
                    AlbumId = Album1,
                    TagId = Tag1
                },
                new AlbumTag
                {
                    AlbumId = Album1,
                    TagId = Tag5
                },
                new AlbumTag
                {
                    AlbumId = Album1,
                    TagId = Tag2
                },
                new AlbumTag
                {
                    AlbumId = Album2,
                    TagId = Tag3
                },
                new AlbumTag
                {
                    AlbumId = Album2,
                    TagId = Tag1
                },
                new AlbumTag
                {
                    AlbumId = Album2,
                    TagId = Tag5
                },
                new AlbumTag
                {
                    AlbumId = Album2,
                    TagId = Tag2
                });

            context.AlbumLikes.AddRange(
                new AlbumLike
                {
                    UserId = UserAId,
                    AlbumId = Album1
                },
                new AlbumLike
                {
                    UserId = UserAId,
                    AlbumId = Album3
                },
                new AlbumLike
                {
                    UserId = UserAId,
                    AlbumId = Album2
                },
                new AlbumLike
                {
                    UserId = UserBId,
                    AlbumId = Album4
                },
                new AlbumLike
                {
                    UserId = UserBId,
                    AlbumId = Album2
                });

            context.Tags.AddRange(
                new Tag
                {
                    Id = Tag1,
                    Name = "Тег 1"
                },
                new Tag
                {
                    Id = Tag2,
                    Name = "Тег 2"
                },
                new Tag
                {
                    Id = Tag3,
                    Name = "Тег 3"
                },
                new Tag
                {
                    Id = Tag4,
                    Name = "Тег 4"
                },
                new Tag
                {
                    Id = Tag5,
                    Name = "Тег 5"
                });
            
            context.SaveChanges();
            return context;
        }

        public static void Destroy(PortfolioDbContext context)
        {
            context.Database.EnsureDeleted();
            context.Dispose();
        }
    }
}
