using Microsoft.AspNetCore.Mvc;

namespace MovieService.APIs;

[ApiController()]
public class CustomersController : CustomersControllerBase
{
    public CustomersController(ICustomersService service)
        : base(service) { }
}
