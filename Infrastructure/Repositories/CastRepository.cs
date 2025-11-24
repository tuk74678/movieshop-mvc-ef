using ApplicationCore.Contracts.Repositories;
using ApplicationCore.Entities;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

public class CastRepository: BaseRepository<Cast>, ICastRepository
{
    public CastRepository(MovieShopDbContext dbContext) : base(dbContext)
    {
    }

    public async Task<Cast> GetCastById(int id)
    {
        return await _movieShopDbContext.Casts
            .AsNoTracking()
            .Include(c => c.MovieCasts).ThenInclude(mc => mc.Movie)
            .FirstOrDefaultAsync(c => c.Id == id);
    }
}