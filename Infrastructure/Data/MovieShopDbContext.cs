using ApplicationCore.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data;

public class MovieShopDbContext: DbContext
{
    public MovieShopDbContext(DbContextOptions<MovieShopDbContext> options): base(options)
    {
        
    }
    
    // map entity class to database tables
    public DbSet<Genre> Genres { get; set; }
    public DbSet<Role> Roles { get; set; }
    public DbSet<Cast> Casts { get; set; }
    public DbSet<Movie> Movies { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Movie>(ConfigureMovie); 
    }

    public void ConfigureMovie(EntityTypeBuilder<Movie> builder)
    {
        // fluent api
        // specifies all data types in the table
        builder.ToTable("Movies");
        builder.HasKey(m => m.Id);
        builder.Property(m => m.Title).IsRequired().HasColumnType("nvarchar(256)");
        builder.Property(m => m.Overview).IsRequired();
        builder.Property(m => m.Tagline).HasColumnType("nvarchar(512)");
        builder.Property(m => m.Budget).HasColumnType("decimal(18,4)");
        builder.Property(m => m.Revenue).HasColumnType("decimal(18,4)");
        builder.Property(m => m.BackdropUrl).HasColumnType("nvarchar(2084)");
        builder.Property(m => m.ImdbUrl).HasColumnType("nvarchar(2084)");
        builder.Property(m => m.TmdbUrl).HasColumnType("nvarchar(2084)");
        builder.Property(m => m.CreatedBy).HasColumnType("nvarchar(max)");
        builder.Property(m => m.CreatedDate).HasColumnType("datetime2");
        builder.Property(m => m.OriginalLanguage).HasColumnType("nvarchar(64)");
        builder.Property(m => m.PosterUrl).HasColumnType("nvarchar(2084)");
        builder.Property(m => m.Price).HasColumnType("decimal(5,2)");
        builder.Property(m => m.ReleaseDate).HasColumnType("datetime2");
        builder.Property(m => m.RunTime).HasColumnType("int");
        builder.Property(m => m.UpdatedBy).HasColumnType("nvarchar(max)");
        builder.Property(m => m.UpdatedDate).HasColumnType("datetime2");
    }
    
}