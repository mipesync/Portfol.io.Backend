using AutoMapper;
using Dapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Npgsql;
using Portfol.io.Application.Common.Exceptions;
using Portfol.io.Application.Interfaces;
using Portfol.io.Domain;
using System.Data;

namespace Portfol.io.Application.Aggregate.Albums.Queries.GetAlbumById
{
    public class GetAlbumByIdQueryHandler : IRequestHandler<GetAlbumByIdQuery, AlbumLookupDto>
    {
        private readonly IPortfolioDbContext _dbContext;
        private readonly IConfiguration _config;
        private readonly IMapper _mapper;

        public GetAlbumByIdQueryHandler(IPortfolioDbContext dbContext, IMapper mapper, IConfiguration config)
        {
            _dbContext = dbContext;
            _mapper = mapper;
            _config = config;
        }

        public async Task<AlbumLookupDto> Handle(GetAlbumByIdQuery request, CancellationToken cancellationToken)
        {
            var entity = await _dbContext.Albums.Include(u => u.Photos).Include(u => u.Tags).Include(u => u.AlbumLikes)
                .FirstOrDefaultAsync(u => u.Id == request.Id, cancellationToken);

            entity!.Views++;

            if (entity is null || entity.Id != request.Id) throw new NotFoundException(nameof(Album), request.Id);

            var dto = _mapper.Map<AlbumLookupDto>(entity);
            if (entity.AlbumLikes!.Any(u => u.UserId == request.UserId))
                dto.IsLiked = true;

            await _dbContext.SaveChangesAsync(cancellationToken);

            return dto;

            /*Album album = null;
            var photos = new List<Photo>();
            var tags = new List<Tag>();
            var sqlExpression = "SELECT * FROM(" +
                $"SELECT * FROM \"Albums\" AS \"a\" WHERE \"a\".\"Id\" = '{request.Id}' LIMIT 1 ) AS \"t\" LEFT JOIN \"Photos\" AS \"p\" ON \"t\".\"Id\" = \"p\".\"AlbumId\"" +
                "LEFT JOIN(" +
                    "SELECT \"a0\".\"AlbumId\", \"a0\".\"TagId\", \"t1\".\"Id\", \"t1\".\"Name\" FROM \"AlbumTags\" AS a0 " +
                    "INNER JOIN \"Tags\" AS \"t1\" ON \"a0\".\"TagId\" = \"t1\".\"Id\") AS \"t0\" ON t.\"Id\" = \"t0\".\"AlbumId\"" +
                    "LEFT JOIN \"AlbumLikes\" AS \"a1\" ON \"t\".\"Id\" = \"a1\".\"AlbumId\"" +
                    "ORDER BY \"t\".\"Id\", \"p\".\"Id\", \"t0\".\"AlbumId\", \"t0\".\"TagId\", \"t0\".\"Id\", \"a1\".\"AlbumId\"";

            using(IDbConnection db = new NpgsqlConnection(_config["PostgreSQL"].ToString()))
            {
                album = db.Query<Album>(sqlExpression).First();
            }*/

            /*using(var connection = new NpgsqlConnection(_config["PostgreSQL"].ToString()))
            {
                connection.Open();

                var command = new NpgsqlCommand(sqlExpression, connection);
                using(var reader = command.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            album = new Album
                            {
                                Id = Guid.Parse(reader["Id"].ToString()!),
                                Name = reader["Name"].ToString()!,
                                Description = reader["Description"].ToString()!,
                                CreationDate = DateTime.Parse(reader["CreationDate"].ToString()!),
                                UserId = Guid.Parse(reader["UserId"].ToString()!)
                            };

                            photos.Add(new Photo
                            {
                                Id = Guid.Parse(reader["Id"].ToString()!),
                                Path = reader["Path"].ToString()!,
                                AlbumId = Guid.Parse(reader["AlbumId"].ToString()!),
                            });

                            tags.Add(new Tag
                            {
                                Id = Guid.Parse(reader["Id"].ToString()!),
                                Name = reader["Name"].ToString()!
                            });
                        }
                    }
                }
            }

            return new AlbumViewModel();*/
        }
    }
}
