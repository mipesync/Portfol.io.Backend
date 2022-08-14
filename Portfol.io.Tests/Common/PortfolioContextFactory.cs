using Microsoft.EntityFrameworkCore;
using Portfol.io.Domain;
using Portfol.io.Persistence;

namespace Portfol.io.Tests.Common
{
    public class PortfolioContextFactory
    {
        public static Guid UserAId = Guid.Parse("0B7784DC-2A9A-45B9-B62B-74D2F3BA0A37");
        public static Guid UserBId = Guid.Parse("4093ADD3-21F8-4069-BE01-38D1E031A997");
        public static string UserAPassHash = "$2a$11$9P6fytUJUIblu61R02Xp.efgA779vlidWZAo9q4ktQOrFC5y7.Jou";
        public static string UserBPassHash = "$2a$11$m7ZMFbtWm1iZfgGJRLRk0.oZ2/2PO9Haq46DqJhWGfcrc1RjUUuq2";

        public static PortfolioDbContext Create()
        {
            var options = new DbContextOptionsBuilder<PortfolioDbContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;

            var context = new PortfolioDbContext(options);
            context.Database.EnsureCreated();

            context.Roles.AddRange(
                new Role
                {
                    Id = 1,
                    Name = "employee"
                },
                new Role
                {
                    Id = 2,
                    Name = "employer"
                });

            context.Credentials.AddRange(
                new Credential
                {
                    Id = 1,
                    Username = "guestos",
                    Password = UserAPassHash //guestos
                },
                new Credential
                {
                    Id = 2,
                    Username = "adminous",
                    Password = UserBPassHash //adminous
                });

            context.Users.AddRange(
                new User
                {
                    Id = UserAId,
                    Name = "Гуестов Гуест Гуестович",
                    Description = "Я - Гуестов Гуест Гуестович",
                    ProfileImagePath = "/ProfileImages/default.png",
                    DateOfBirth = DateOnly.Parse("02.04.2023"),
                    DateOfCreation = DateTime.UtcNow,
                    Email = "guestos@aaa.moc",
                    CredentialsId = 1,
                    RoleId = 1,
                    VerifyCode = "123456"
                },
                new User
                {
                    Id = UserBId,
                    Name = "Админосов Админос Админосович",
                    Description = "Я - Админосов Админос Админосович",
                    ProfileImagePath = "/ProfileImages/default.png",
                    DateOfBirth = DateOnly.Parse("02.04.2010"),
                    DateOfCreation = DateTime.UtcNow,
                    Email = "adminous@aaa.moc",
                    CredentialsId = 2,
                    RoleId = 2,
                    VerifyCode = "123456"
                });

            context.Albums.AddRange(
                new Album
                {
                    Id = 1,
                    Name = "Альбом Гуеста 1",
                    CreationDate = DateTime.UtcNow,
                    UserId = UserAId
                },
                new Album
                {
                    Id = 2,
                    Name = "Альбом Гуеста 2",
                    CreationDate = DateTime.UtcNow,
                    UserId = UserAId
                },
                new Album
                {
                    Id = 3,
                    Name = "Альбом Админоса 1",
                    CreationDate = DateTime.UtcNow,
                    UserId = UserBId
                },
                new Album
                {
                    Id = 4,
                    Name = "Альбом Админоса 2",
                    CreationDate = DateTime.UtcNow,
                    UserId = UserBId
                });

            context.Photos.AddRange(
                new Photo
                {
                    Id = 1,
                    Path = "some_url",
                    AlbumId = 1
                },
                new Photo
                {
                    Id = 2,
                    Path = "some_url",
                    AlbumId = 1
                },
                new Photo
                {
                    Id = 3,
                    Path = "some_url",
                    AlbumId = 1
                },
                new Photo
                {
                    Id = 4,
                    Path = "some_url",
                    AlbumId = 2
                },
                new Photo
                {
                    Id = 5,
                    Path = "some_url",
                    AlbumId = 2
                });

            context.AlbumTags.AddRange(
                new AlbumTag
                {
                    AlbumId = 1,
                    TagId = 1
                },
                new AlbumTag
                {
                    AlbumId = 1,
                    TagId = 3
                },
                new AlbumTag
                {
                    AlbumId = 1,
                    TagId = 5
                },
                new AlbumTag
                {
                    AlbumId = 2,
                    TagId = 1
                },
                new AlbumTag
                {
                    AlbumId = 2,
                    TagId = 2
                },
                new AlbumTag
                {
                    AlbumId = 2,
                    TagId = 4
                },
                new AlbumTag
                {
                    AlbumId = 2,
                    TagId = 5
                });

            context.AlbumLikes.AddRange(
                new AlbumLike
                {
                    UserId = UserAId,
                    AlbumId = 1
                },
                new AlbumLike
                {
                    UserId = UserAId,
                    AlbumId = 2
                },
                new AlbumLike
                {
                    UserId = UserAId,
                    AlbumId = 3
                },
                new AlbumLike
                {
                    UserId = UserAId,
                    AlbumId = 4
                },
                new AlbumLike
                {
                    UserId = UserBId,
                    AlbumId = 2
                },
                new AlbumLike
                {
                    UserId = UserBId,
                    AlbumId = 3
                });

            context.Tags.AddRange(
                new Tag
                {
                    Id = 1,
                    Name = "Тег 1"
                },
                new Tag
                {
                    Id = 2,
                    Name = "Тег 2"
                },
                new Tag
                {
                    Id = 3,
                    Name = "Тег 3"
                },
                new Tag
                {
                    Id = 4,
                    Name = "Тег 4"
                },
                new Tag
                {
                    Id = 5,
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
