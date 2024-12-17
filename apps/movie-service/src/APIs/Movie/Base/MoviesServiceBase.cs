using Microsoft.EntityFrameworkCore;
using MovieService.APIs;
using MovieService.APIs.Common;
using MovieService.APIs.Dtos;
using MovieService.APIs.Errors;
using MovieService.APIs.Extensions;
using MovieService.Infrastructure;
using MovieService.Infrastructure.Models;

namespace MovieService.APIs;

public abstract class MoviesServiceBase : IMoviesService
{
    protected readonly MovieServiceDbContext _context;

    public MoviesServiceBase(MovieServiceDbContext context)
    {
        _context = context;
    }

    /// <summary>
    /// Create one movie
    /// </summary>
    public async Task<Movie> CreateMovie(MovieCreateInput createDto)
    {
        var movie = new MovieDbModel
        {
            CreatedAt = createDto.CreatedAt,
            Description = createDto.Description,
            Duration = createDto.Duration,
            ReleaseDate = createDto.ReleaseDate,
            Title = createDto.Title,
            UpdatedAt = createDto.UpdatedAt
        };

        if (createDto.Id != null)
        {
            movie.Id = createDto.Id;
        }
        if (createDto.Customer != null)
        {
            movie.Customer = await _context
                .Customers.Where(customer => createDto.Customer.Id == customer.Id)
                .FirstOrDefaultAsync();
        }

        _context.Movies.Add(movie);
        await _context.SaveChangesAsync();

        var result = await _context.FindAsync<MovieDbModel>(movie.Id);

        if (result == null)
        {
            throw new NotFoundException();
        }

        return result.ToDto();
    }

    /// <summary>
    /// Delete one movie
    /// </summary>
    public async Task DeleteMovie(MovieWhereUniqueInput uniqueId)
    {
        var movie = await _context.Movies.FindAsync(uniqueId.Id);
        if (movie == null)
        {
            throw new NotFoundException();
        }

        _context.Movies.Remove(movie);
        await _context.SaveChangesAsync();
    }

    /// <summary>
    /// Find many movies
    /// </summary>
    public async Task<List<Movie>> Movies(MovieFindManyArgs findManyArgs)
    {
        var movies = await _context
            .Movies.Include(x => x.Customer)
            .ApplyWhere(findManyArgs.Where)
            .ApplySkip(findManyArgs.Skip)
            .ApplyTake(findManyArgs.Take)
            .ApplyOrderBy(findManyArgs.SortBy)
            .ToListAsync();
        return movies.ConvertAll(movie => movie.ToDto());
    }

    /// <summary>
    /// Meta data about movie records
    /// </summary>
    public async Task<MetadataDto> MoviesMeta(MovieFindManyArgs findManyArgs)
    {
        var count = await _context.Movies.ApplyWhere(findManyArgs.Where).CountAsync();

        return new MetadataDto { Count = count };
    }

    /// <summary>
    /// Get one movie
    /// </summary>
    public async Task<Movie> Movie(MovieWhereUniqueInput uniqueId)
    {
        var movies = await this.Movies(
            new MovieFindManyArgs { Where = new MovieWhereInput { Id = uniqueId.Id } }
        );
        var movie = movies.FirstOrDefault();
        if (movie == null)
        {
            throw new NotFoundException();
        }

        return movie;
    }

    /// <summary>
    /// Update one movie
    /// </summary>
    public async Task UpdateMovie(MovieWhereUniqueInput uniqueId, MovieUpdateInput updateDto)
    {
        var movie = updateDto.ToModel(uniqueId);

        if (updateDto.Customer != null)
        {
            movie.Customer = await _context
                .Customers.Where(customer => updateDto.Customer == customer.Id)
                .FirstOrDefaultAsync();
        }

        _context.Entry(movie).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!_context.Movies.Any(e => e.Id == movie.Id))
            {
                throw new NotFoundException();
            }
            else
            {
                throw;
            }
        }
    }

    /// <summary>
    /// Get a Customer record for movie
    /// </summary>
    public async Task<Customer> GetCustomer(MovieWhereUniqueInput uniqueId)
    {
        var movie = await _context
            .Movies.Where(movie => movie.Id == uniqueId.Id)
            .Include(movie => movie.Customer)
            .FirstOrDefaultAsync();
        if (movie == null)
        {
            throw new NotFoundException();
        }
        return movie.Customer.ToDto();
    }
}
