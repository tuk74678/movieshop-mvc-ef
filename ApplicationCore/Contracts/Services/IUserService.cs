using ApplicationCore.Models;

namespace ApplicationCore.Contracts.Services;

public interface IUserService
{
    Task<List<PurchasedMovieModel>> GetPurchasedMovies(int userId);
}