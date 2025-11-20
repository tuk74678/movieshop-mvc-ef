using ApplicationCore.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data;

public class MovieShopDbContext: DbContext
{
    public MovieShopDbContext(DbContextOptions<MovieShopDbContext> options): base(options)
    {
        
    }
    
    // map entity class to database tables
    public DbSet<Genre> Genres { get; set; }
}