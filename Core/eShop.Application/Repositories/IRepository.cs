namespace eShop.Application.Repositories;

public interface IRepository<T> where T : BaseEntity
{
    DbSet<T> Table { get; }

    bool Exists(T entity);
    Task<bool> ExistsAsync(T entity);

    bool Exists(string id);
    Task<bool> ExistsAsync(string id);
}
