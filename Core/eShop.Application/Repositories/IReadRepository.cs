namespace eShop.Application.Repositories;

public interface IReadRepository<T>: IRepository<T> where T : BaseEntity
{
    T Get(string id, bool tracking = true);
    Task<T> GetAsync(string id, bool tracking = true);

    T Get(Expression<Func<T, bool>> method, bool tracking = true);
    Task<T> GetAsync(Expression<Func<T, bool>> method, bool tracking = true);

    IQueryable<T> GetAll(bool tracking = true);
    Task<IQueryable<T>> GetAllAsync(bool tracking = true);

    IQueryable<T> GetWhere(Expression<Func<T, bool>> method, bool tracking = true);
    Task<IQueryable<T>> GetWhereAsync(Expression<Func<T, bool>> method, bool tracking = true);
}
