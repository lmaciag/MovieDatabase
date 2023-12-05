using Microsoft.EntityFrameworkCore;
using MovieDatabase.Core.Entities;

namespace MovieDatabase.Infrastructure;

public class MovieDbContext : DbContext
{
    public DbSet<Movie> Movies { get; set; }
    
    public DbSet<MovieDirector> Directors { get; set; }
    
    public DbSet<MovieActor> Actors { get; set; }
    
    public MovieDbContext(DbContextOptions<MovieDbContext> options) : base(options)
    {
    }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(GetType().Assembly);
    }
}