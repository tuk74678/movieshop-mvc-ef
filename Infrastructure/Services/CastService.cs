using ApplicationCore.Contracts.Repositories;
using ApplicationCore.Contracts.Services;
using ApplicationCore.Models;

namespace Infrastructure.Services;

public class CastService: ICastService
{
    private readonly ICastRepository castRepository;
    public CastService(ICastRepository _castRepository)
    {
        castRepository = _castRepository;
    }
    public async Task<CastDetailsModel> GetCastDetailsAsync(int id)
    {
        var cast = await castRepository.GetCastByIdAsync(id); // await async method

        if (cast == null)
            return null;

        return new CastDetailsModel()
        {
            Id = cast.Id,
            Gender = cast.Gender,
            Name = cast.Name,
            ProfilePath = cast.ProfilePath,
            TmdbUrl = cast.TmdbUrl,
 
            Movies = cast.MovieCasts.Select(mc => new MovieCardModel()
            {
                Id = mc.MovieId,
                Title = mc.Movie.Title,
                PosterUrl = mc.Movie.PosterUrl,
                Character = mc.Character
            }).ToList(),
        };
    }
}