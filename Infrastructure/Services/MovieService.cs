using ApplicationCore.Contracts.Repositories;
using ApplicationCore.Contracts.Services;
using ApplicationCore.Entities;
using ApplicationCore.Models;

namespace Infrastructure.Services;

public class MovieService: IMovieService
{
    private readonly IMovieRepository movieRepository;
    public MovieService(IMovieRepository _movieRepository)
    {
        movieRepository = _movieRepository;
    }
    // get the top 20 movie
    // Optimized Top 20 movies
    public async Task<List<MovieCardModel>> Top20MoviesAsync()
    {
        var movies = await movieRepository.GetTop20MoviesAsync(); // await async call

        return movies.Select(m => new MovieCardModel
        {
            Id = m.Id,
            Title = m.Title,
            PosterUrl = m.PosterUrl
        }).ToList();
    }

    // Optimized Get movies by genre
    public async Task<IEnumerable<Movie>> GetMoviesByGenreAsync(int genreId)
    {
        return await movieRepository.GetMoviesByGenreAsync(genreId); // just await
    }

    // Optimized Get movie details
    public async Task<MovieDetailsModel> GetMovieDetails(int id)
    {
        var movie = await movieRepository.GetMovieById(id); // await async method

        if (movie == null)
            return null;

        return new MovieDetailsModel
        {
            Id = movie.Id,
            Title = movie.Title,
            Overview = movie.Overview,
            Tagline = movie.Tagline,
            Budget = movie.Budget,
            Revenue = movie.Revenue,
            BackdropUrl = movie.BackdropUrl,
            ImdbUrl = movie.ImdbUrl,
            TmdbUrl = movie.TmdbUrl,
            ReleaseDate = movie.ReleaseDate,
            RunTime = movie.RunTime,
            Price = movie.Price,
            PosterUrl = movie.PosterUrl,
            Genres = movie.MovieGenres.Select(g => new GenreModel
            {
                Id = g.GenreId,
                Name = g.Genre.Name
            }).ToList(),
            Casts = movie.MovieCasts.Select(c => new CastModel
            {
                Id = c.CastId,
                Name = c.Cast.Name,
                ProfilePath = c.Cast.ProfilePath,
                Character = c.Character
            }).ToList(),
            Trailers = movie.Trailers.Select(t => new TrailerModel
            {
                Id = t.Id,
                Name = t.Name,
                TrailerUrl = t.TrailerUrl
            }).ToList()
        };
    }
    
}