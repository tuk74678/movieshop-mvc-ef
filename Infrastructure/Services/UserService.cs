using ApplicationCore.Contracts.Repositories;
using ApplicationCore.Contracts.Services;
using ApplicationCore.Models;

namespace Infrastructure.Services;

public class UserService: IUserService
{
    private readonly IPurchaseRepository  _purchaseRepository;
    private readonly IMovieRepository _movieRepository;
    public UserService(IPurchaseRepository  purchaseRepository, IMovieRepository movieRepository)
    {
        _purchaseRepository = purchaseRepository;
        _movieRepository = movieRepository;
    }
    public async Task<List<PurchasedMovieModel>> GetPurchasedMovies(int userId)
    {
        // Get all purchases for the user, including movie details
        var purchases = await _purchaseRepository.GetPurchasesByUser(userId);

        var purchasedMovies = purchases.Select(p => new PurchasedMovieModel
        {
            MovieId = p.MovieId,
            UserId = p.UserId,
            PurchaseDateTime = p.PurchaseDateTime,
            PurchaseNumber = Guid.NewGuid(), // Or store it in DB if you have a column
            TotalPrice = p.TotalPrice,
            Movie = new MovieCardModel
            {
                Id = p.Movie.Id,
                Title = p.Movie.Title,
                PosterUrl = p.Movie.PosterUrl
            }
        }).ToList();

        return purchasedMovies;
    }
    
}