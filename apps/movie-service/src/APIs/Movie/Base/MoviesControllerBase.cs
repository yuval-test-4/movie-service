using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MovieService.APIs;
using MovieService.APIs.Common;
using MovieService.APIs.Dtos;
using MovieService.APIs.Errors;

namespace MovieService.APIs;

[Route("api/[controller]")]
[ApiController()]
public abstract class MoviesControllerBase : ControllerBase
{
    protected readonly IMoviesService _service;

    public MoviesControllerBase(IMoviesService service)
    {
        _service = service;
    }

    /// <summary>
    /// Create one movie
    /// </summary>
    [HttpPost()]
    [Authorize(Roles = "user")]
    public async Task<ActionResult<Movie>> CreateMovie(MovieCreateInput input)
    {
        var movie = await _service.CreateMovie(input);

        return CreatedAtAction(nameof(Movie), new { id = movie.Id }, movie);
    }

    /// <summary>
    /// Delete one movie
    /// </summary>
    [HttpDelete("{Id}")]
    [Authorize(Roles = "user")]
    public async Task<ActionResult> DeleteMovie([FromRoute()] MovieWhereUniqueInput uniqueId)
    {
        try
        {
            await _service.DeleteMovie(uniqueId);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }

    /// <summary>
    /// Find many movies
    /// </summary>
    [HttpGet()]
    [Authorize(Roles = "user")]
    public async Task<ActionResult<List<Movie>>> Movies([FromQuery()] MovieFindManyArgs filter)
    {
        return Ok(await _service.Movies(filter));
    }

    /// <summary>
    /// Meta data about movie records
    /// </summary>
    [HttpPost("meta")]
    public async Task<ActionResult<MetadataDto>> MoviesMeta([FromQuery()] MovieFindManyArgs filter)
    {
        return Ok(await _service.MoviesMeta(filter));
    }

    /// <summary>
    /// Get one movie
    /// </summary>
    [HttpGet("{Id}")]
    [Authorize(Roles = "user")]
    public async Task<ActionResult<Movie>> Movie([FromRoute()] MovieWhereUniqueInput uniqueId)
    {
        try
        {
            return await _service.Movie(uniqueId);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }
    }

    /// <summary>
    /// Update one movie
    /// </summary>
    [HttpPatch("{Id}")]
    [Authorize(Roles = "user")]
    public async Task<ActionResult> UpdateMovie(
        [FromRoute()] MovieWhereUniqueInput uniqueId,
        [FromQuery()] MovieUpdateInput movieUpdateDto
    )
    {
        try
        {
            await _service.UpdateMovie(uniqueId, movieUpdateDto);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }

    /// <summary>
    /// Get a Customer record for movie
    /// </summary>
    [HttpGet("{Id}/customer")]
    public async Task<ActionResult<List<Customer>>> GetCustomer(
        [FromRoute()] MovieWhereUniqueInput uniqueId
    )
    {
        var customer = await _service.GetCustomer(uniqueId);
        return Ok(customer);
    }
}
