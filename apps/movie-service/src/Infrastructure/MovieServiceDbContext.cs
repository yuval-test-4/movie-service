using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MovieService.Infrastructure.Models;

namespace MovieService.Infrastructure;

public class MovieServiceDbContext : IdentityDbContext<IdentityUser>
{
    public MovieServiceDbContext(DbContextOptions<MovieServiceDbContext> options)
        : base(options) { }

    public DbSet<CustomerDbModel> Customers { get; set; }

    public DbSet<MovieDbModel> Movies { get; set; }
}
