using MovieService.Infrastructure;

namespace MovieService.APIs;

public class CustomersService : CustomersServiceBase
{
    public CustomersService(MovieServiceDbContext context)
        : base(context) { }
}
