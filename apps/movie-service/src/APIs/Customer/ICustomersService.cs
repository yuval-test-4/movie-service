using MovieService.APIs.Common;
using MovieService.APIs.Dtos;

namespace MovieService.APIs;

public interface ICustomersService
{
    /// <summary>
    /// Create one customer
    /// </summary>
    public Task<Customer> CreateCustomer(CustomerCreateInput customer);

    /// <summary>
    /// Delete one customer
    /// </summary>
    public Task DeleteCustomer(CustomerWhereUniqueInput uniqueId);

    /// <summary>
    /// Find many customers
    /// </summary>
    public Task<List<Customer>> Customers(CustomerFindManyArgs findManyArgs);

    /// <summary>
    /// Meta data about customer records
    /// </summary>
    public Task<MetadataDto> CustomersMeta(CustomerFindManyArgs findManyArgs);

    /// <summary>
    /// Get one customer
    /// </summary>
    public Task<Customer> Customer(CustomerWhereUniqueInput uniqueId);

    /// <summary>
    /// Update one customer
    /// </summary>
    public Task UpdateCustomer(CustomerWhereUniqueInput uniqueId, CustomerUpdateInput updateDto);

    /// <summary>
    /// Connect multiple movies records to customer
    /// </summary>
    public Task ConnectMovies(CustomerWhereUniqueInput uniqueId, MovieWhereUniqueInput[] moviesId);

    /// <summary>
    /// Disconnect multiple movies records from customer
    /// </summary>
    public Task DisconnectMovies(
        CustomerWhereUniqueInput uniqueId,
        MovieWhereUniqueInput[] moviesId
    );

    /// <summary>
    /// Find multiple movies records for customer
    /// </summary>
    public Task<List<Movie>> FindMovies(
        CustomerWhereUniqueInput uniqueId,
        MovieFindManyArgs MovieFindManyArgs
    );

    /// <summary>
    /// Update multiple movies records for customer
    /// </summary>
    public Task UpdateMovies(CustomerWhereUniqueInput uniqueId, MovieWhereUniqueInput[] moviesId);
}
