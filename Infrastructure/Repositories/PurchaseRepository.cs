using ApplicationCore.Contracts.Repositories;
using ApplicationCore.Entities;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

public class PurchaseRepository: BaseRepository<Purchase>, IPurchaseRepository
{
    public PurchaseRepository(MovieShopDbContext dbContext) : base(dbContext)
    {
    }
    // Check if the user purchased the movie
    public async Task<Purchase> GetPurchaseByUserAndMovieAsync(int userId, int movieId)
    {
        return await _movieShopDbContext.Purchases
            .Include(p => p.Movie)
            .FirstOrDefaultAsync(p => p.UserId == userId && p.MovieId == movieId);
    }
    // Add a new purhcase
    public async Task AddPurchaseAsync(Purchase purchase)
    {
        await _movieShopDbContext.Purchases.AddAsync(purchase);
        await _movieShopDbContext.SaveChangesAsync();
    }
    // Fetch the purchased movies
    public async Task<List<Purchase>> GetPurchasesByUserAsync(int userId)
    {
        return await _movieShopDbContext.Purchases
            .Include(p => p.Movie) // This ensures Movie is loaded
            .Where(p => p.UserId == userId)
            .ToListAsync();
    }
}