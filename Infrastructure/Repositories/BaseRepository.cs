using ApplicationCore.Contracts.Repositories;
using Infrastructure.Data;

namespace Infrastructure.Repositories;

public class BaseRepository<T>: IRepository<T> where T: class
{
    // use Dependency Injection to inject DbContext Class, use readonly to avoid further initialization
    protected readonly MovieShopDbContext _movieShopDbContext;
    public BaseRepository(MovieShopDbContext movieShopDbContext)
    {
        _movieShopDbContext = movieShopDbContext;
    }
    public T Insert(T entity)
    {
        throw new NotImplementedException();
    }

    public T DeleteById(int id)
    {
        throw new NotImplementedException();
    }

    public T Update(T entity)
    {
        throw new NotImplementedException();
    }

    public IEnumerable<T> GetAll()
    {
        throw new NotImplementedException();
    }

    public T GetById(int id)
    {
        throw new NotImplementedException();
    }
}