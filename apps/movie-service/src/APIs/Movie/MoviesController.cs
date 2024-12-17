using Microsoft.AspNetCore.Mvc;

namespace MovieService.APIs;

[ApiController()]
public class MoviesController : MoviesControllerBase
{
    public MoviesController(IMoviesService service)
        : base(service) { }
}
