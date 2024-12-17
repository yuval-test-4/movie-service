using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MovieService.APIs;
using MovieService.APIs.Common;
using MovieService.APIs.Dtos;
using MovieService.APIs.Errors;

namespace MovieService.APIs;

[Route("api/[controller]")]
[ApiController()]
public abstract class CustomersControllerBase : ControllerBase
{
    protected readonly ICustomersService _service;

    public CustomersControllerBase(ICustomersService service)
    {
        _service = service;
    }

    /// <summary>
    /// Create one customer
    /// </summary>
    [HttpPost()]
    [Authorize(Roles = "user")]
    public async Task<ActionResult<Customer>> CreateCustomer(CustomerCreateInput input)
    {
        var customer = await _service.CreateCustomer(input);

        return CreatedAtAction(nameof(Customer), new { id = customer.Id }, customer);
    }

    /// <summary>
    /// Delete one customer
    /// </summary>
    [HttpDelete("{Id}")]
    [Authorize(Roles = "user")]
    public async Task<ActionResult> DeleteCustomer([FromRoute()] CustomerWhereUniqueInput uniqueId)
    {
        try
        {
            await _service.DeleteCustomer(uniqueId);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }

    /// <summary>
    /// Find many customers
    /// </summary>
    [HttpGet()]
    [Authorize(Roles = "user")]
    public async Task<ActionResult<List<Customer>>> Customers(
        [FromQuery()] CustomerFindManyArgs filter
    )
    {
        return Ok(await _service.Customers(filter));
    }

    /// <summary>
    /// Meta data about customer records
    /// </summary>
    [HttpPost("meta")]
    public async Task<ActionResult<MetadataDto>> CustomersMeta(
        [FromQuery()] CustomerFindManyArgs filter
    )
    {
        return Ok(await _service.CustomersMeta(filter));
    }

    /// <summary>
    /// Get one customer
    /// </summary>
    [HttpGet("{Id}")]
    [Authorize(Roles = "user")]
    public async Task<ActionResult<Customer>> Customer(
        [FromRoute()] CustomerWhereUniqueInput uniqueId
    )
    {
        try
        {
            return await _service.Customer(uniqueId);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }
    }

    /// <summary>
    /// Update one customer
    /// </summary>
    [HttpPatch("{Id}")]
    [Authorize(Roles = "user")]
    public async Task<ActionResult> UpdateCustomer(
        [FromRoute()] CustomerWhereUniqueInput uniqueId,
        [FromQuery()] CustomerUpdateInput customerUpdateDto
    )
    {
        try
        {
            await _service.UpdateCustomer(uniqueId, customerUpdateDto);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }

    /// <summary>
    /// Connect multiple movies records to customer
    /// </summary>
    [HttpPost("{Id}/movies")]
    [Authorize(Roles = "user")]
    public async Task<ActionResult> ConnectMovies(
        [FromRoute()] CustomerWhereUniqueInput uniqueId,
        [FromQuery()] MovieWhereUniqueInput[] moviesId
    )
    {
        try
        {
            await _service.ConnectMovies(uniqueId, moviesId);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }

    /// <summary>
    /// Disconnect multiple movies records from customer
    /// </summary>
    [HttpDelete("{Id}/movies")]
    [Authorize(Roles = "user")]
    public async Task<ActionResult> DisconnectMovies(
        [FromRoute()] CustomerWhereUniqueInput uniqueId,
        [FromBody()] MovieWhereUniqueInput[] moviesId
    )
    {
        try
        {
            await _service.DisconnectMovies(uniqueId, moviesId);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }

    /// <summary>
    /// Find multiple movies records for customer
    /// </summary>
    [HttpGet("{Id}/movies")]
    [Authorize(Roles = "user")]
    public async Task<ActionResult<List<Movie>>> FindMovies(
        [FromRoute()] CustomerWhereUniqueInput uniqueId,
        [FromQuery()] MovieFindManyArgs filter
    )
    {
        try
        {
            return Ok(await _service.FindMovies(uniqueId, filter));
        }
        catch (NotFoundException)
        {
            return NotFound();
        }
    }

    /// <summary>
    /// Update multiple movies records for customer
    /// </summary>
    [HttpPatch("{Id}/movies")]
    [Authorize(Roles = "user")]
    public async Task<ActionResult> UpdateMovies(
        [FromRoute()] CustomerWhereUniqueInput uniqueId,
        [FromBody()] MovieWhereUniqueInput[] moviesId
    )
    {
        try
        {
            await _service.UpdateMovies(uniqueId, moviesId);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }
}
