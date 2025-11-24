using ApplicationCore.Entities;

namespace ApplicationCore.Contracts.Repositories;

public interface IPurchaseRepository: IRepository<Purchase>
{
    Task<Purchase> GetPurchaseByUserAndMovie(int userId, int movieId);
    Task AddPurchaseAsync(Purchase purchase);
    Task<List<Purchase>> GetPurchasesByUser(int userId);
}