namespace eShop.Persistence.Repositories;

public class WriteRepository<T> : IWriteRepository<T> where T : BaseEntity
{
    private readonly AppDbContext _dbContext;

    public DbSet<T> Table => _dbContext.Set<T>();


    public WriteRepository(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }


    public bool Exists(T entity) => Table.Contains(entity);
    public async Task<bool> ExistsAsync(T entity) => await Task.Factory.StartNew(() => Exists(entity));

    public bool Exists(string id)
    {
        Guid.TryParse(id, out Guid guid);

        var entity = Table.FirstOrDefault(e => e.Id == guid);
        return entity is not null ? true : false;
    }
    public async Task<bool> ExistsAsync(string id) => await Task.Factory.StartNew(() => Exists(id));

    public bool Add(T entity)
    {
        var result = Table.Add(entity);
        _dbContext.SaveChanges();

        return result.State == EntityState.Unchanged;
    }
    public async Task<bool> AddAsync(T entity) => await Task.Factory.StartNew(() => Add(entity));

    public bool AddRange(ICollection<T> entities)
    {
        Table.AddRange(entities);
        return true;
    }
    public async Task<bool> AddRangeAsync(ICollection<T> entities) => await Task.Factory.StartNew(() => AddRange(entities));

    public bool Remove(T entity)
    {
        var result = Table.Remove(entity);
        return result.State == EntityState.Deleted;
    }
    public async Task<bool> RemoveAsync(T entity) => await Task.Factory.StartNew(() => Remove(entity));

    public bool Remove(string id)
    {
        Guid.TryParse(id, out Guid guid);

        var model = Table.Find(guid);
        var result = Table.Remove(model);
        return result.State == EntityState.Deleted;
    }
    public async Task<bool> RemoveAsync(string id) => await Task.Factory.StartNew(() => Remove(id));

    public bool Update(T entity)
    {
        var result = Table.Update(entity);
        return result.State == EntityState.Modified;
    }
    public async Task<bool> UpdateAsync(T entity) => await Task.Factory.StartNew(() => Update(entity));

    public int SaveChanges() => _dbContext.SaveChanges();
    public async Task<int> SaveChangesAsync() => await _dbContext.SaveChangesAsync();
}
