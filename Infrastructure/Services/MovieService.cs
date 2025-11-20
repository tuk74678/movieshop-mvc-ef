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
    public List<MovieCardModel> Top20Movies()
    {
        var movies = movieRepository.GetTop20Movies();
        var movieCardModels = new List<MovieCardModel>();
        foreach (var movie in movies)
        {
            movieCardModels.Add(new MovieCardModel()
            {
                Id = movie.Id, PosterUrl = movie.PosterUrl, Title = movie.Title
            });
        }

        return movieCardModels;
    }
}