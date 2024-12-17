using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace MovieService.Infrastructure;

public class MovieServiceDbContext : IdentityDbContext<IdentityUser>
{
    public MovieServiceDbContext(DbContextOptions<MovieServiceDbContext> options)
        : base(options) { }
}
