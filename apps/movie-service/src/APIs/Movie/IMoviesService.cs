using MovieService.APIs.Common;
using MovieService.APIs.Dtos;

namespace MovieService.APIs;

public interface IMoviesService
{
    /// <summary>
    /// Create one movie
    /// </summary>
    public Task<Movie> CreateMovie(MovieCreateInput movie);

    /// <summary>
    /// Delete one movie
    /// </summary>
    public Task DeleteMovie(MovieWhereUniqueInput uniqueId);

    /// <summary>
    /// Find many movies
    /// </summary>
    public Task<List<Movie>> Movies(MovieFindManyArgs findManyArgs);

    /// <summary>
    /// Meta data about movie records
    /// </summary>
    public Task<MetadataDto> MoviesMeta(MovieFindManyArgs findManyArgs);

    /// <summary>
    /// Get one movie
    /// </summary>
    public Task<Movie> Movie(MovieWhereUniqueInput uniqueId);

    /// <summary>
    /// Update one movie
    /// </summary>
    public Task UpdateMovie(MovieWhereUniqueInput uniqueId, MovieUpdateInput updateDto);

    /// <summary>
    /// Get a Customer record for movie
    /// </summary>
    public Task<Customer> GetCustomer(MovieWhereUniqueInput uniqueId);
}
