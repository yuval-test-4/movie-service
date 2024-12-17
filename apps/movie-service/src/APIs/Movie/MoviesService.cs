using MovieService.Infrastructure;

namespace MovieService.APIs;

public class MoviesService : MoviesServiceBase
{
    public MoviesService(MovieServiceDbContext context)
        : base(context) { }
}
