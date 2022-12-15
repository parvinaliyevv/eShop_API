namespace eShop.Application.Repositories;

public interface IWriteRepository<T>: IRepository<T> where T : BaseEntity
{
    bool Add(T entity);
    Task<bool> AddAsync(T entity);

    bool AddRange(ICollection<T> entities);
    Task<bool> AddRangeAsync(ICollection<T> entities);

    bool Update(T entity);
    Task<bool> UpdateAsync(T entity);

    bool Remove(T entity);
    Task<bool> RemoveAsync(T entity);

    bool Remove(string id);
    Task<bool> RemoveAsync(string id);

    int SaveChanges();
    Task<int> SaveChangesAsync();
}
