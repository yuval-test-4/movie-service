using MovieService.APIs.Dtos;
using MovieService.Infrastructure.Models;

namespace MovieService.APIs.Extensions;

public static class MoviesExtensions
{
    public static Movie ToDto(this MovieDbModel model)
    {
        return new Movie
        {
            CreatedAt = model.CreatedAt,
            Customer = model.CustomerId,
            Description = model.Description,
            Duration = model.Duration,
            Id = model.Id,
            ReleaseDate = model.ReleaseDate,
            Title = model.Title,
            UpdatedAt = model.UpdatedAt,
        };
    }

    public static MovieDbModel ToModel(
        this MovieUpdateInput updateDto,
        MovieWhereUniqueInput uniqueId
    )
    {
        var movie = new MovieDbModel
        {
            Id = uniqueId.Id,
            Description = updateDto.Description,
            Duration = updateDto.Duration,
            ReleaseDate = updateDto.ReleaseDate,
            Title = updateDto.Title
        };

        if (updateDto.CreatedAt != null)
        {
            movie.CreatedAt = updateDto.CreatedAt.Value;
        }
        if (updateDto.Customer != null)
        {
            movie.CustomerId = updateDto.Customer;
        }
        if (updateDto.UpdatedAt != null)
        {
            movie.UpdatedAt = updateDto.UpdatedAt.Value;
        }

        return movie;
    }
}
