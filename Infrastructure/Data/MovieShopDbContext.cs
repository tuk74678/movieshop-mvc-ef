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
    public DbSet<User> Users { get; set; }
    public DbSet<Trailer> Trailers { get; set; }
    public DbSet<MovieGenre> MovieGenres { get; set; }
    public DbSet<MovieCast> MovieCasts { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Movie>(ConfigureMovie); 
        modelBuilder.Entity<User>(ConfigureUser);
        modelBuilder.Entity<MovieGenre>(ConfigureMovieGenre);
        modelBuilder.Entity<MovieCast>(ConfigureMovieCast);
    }

    private void ConfigureMovieCast(EntityTypeBuilder<MovieCast> modelBuilder)
    {
        modelBuilder.HasKey(mc => new {mc.MovieId, mc.CastId});
        modelBuilder.HasOne(mc => mc.Movie)
            .WithMany(mc=>mc.MovieCasts)
            .HasForeignKey(mc => mc.MovieId);
        modelBuilder.HasOne(mc => mc.Cast)
            .WithMany(mc=>mc.MovieCasts)
            .HasForeignKey(mc=>mc.CastId);
    }

    private void ConfigureMovieGenre(EntityTypeBuilder<MovieGenre> modelBuilder)
    {
        modelBuilder.HasKey(x => new { x.MovieId, x.GenreId });
        modelBuilder.HasOne(x => x.Movie)
            .WithMany(x => x.MovieGenres)
            .HasForeignKey(x => x.MovieId);
        modelBuilder.HasOne(x => x.Genre)
            .WithMany(x => x.MovieGenres)
            .HasForeignKey(x => x.GenreId);

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

    public void ConfigureUser(EntityTypeBuilder<User> builder)
    {
        // fluent api
        // specifies all data types in the table
        builder.ToTable("Users");
        builder.HasKey(u => u.Id);
        builder.Property(m => m.FirstName).IsRequired().HasColumnType("nvarchar(128)");
        builder.Property(m => m.LastName).IsRequired().HasColumnType("nvarchar(128)");
        builder.Property(m => m.DateOfBirth).IsRequired().HasColumnType("datetime2");
        builder.Property(m => m.Email).IsRequired().HasColumnType("nvarchar(256)");
        builder.Property(m => m.PhoneNumber).HasColumnType("nvarchar(16)");
        builder.Property(m => m.HashedPassword).IsRequired().HasColumnType("nvarchar(1024)");
        builder.Property(m => m.ProfilePictureUrl).HasColumnType("nvarchar(max)");
        builder.Property(m => m.IsLocked).HasColumnType("bit");
        builder.Property(m => m.salt).HasColumnType("nvarchar(1024)");
        
    }
    
}