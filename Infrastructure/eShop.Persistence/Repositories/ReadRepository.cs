namespace eShop.Persistence.Repositories;

public class ReadRepository<T> : IReadRepository<T> where T : BaseEntity
{
    private readonly AppDbContext _dbContext;

    public DbSet<T> Table => _dbContext.Set<T>();


    public ReadRepository(AppDbContext dbContext)
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

    public T Get(string id, bool tracking = true)
    {
        Guid.TryParse(id, out Guid guid);

        var models = tracking ? Table.AsQueryable() : Table.AsNoTracking();

        return models.FirstOrDefault(entity => entity.Id == guid);
    }
    public async Task<T> GetAsync(string id, bool tracking = true) => await Task.Factory.StartNew(() => Get(id, tracking));

    public T Get(Expression<Func<T, bool>> method, bool tracking = true)
    {
        var models = tracking ? Table.AsQueryable() : Table.AsNoTracking();

        return models.First(method);
    }
    public async Task<T> GetAsync(Expression<Func<T, bool>> method, bool tracking = true) => await Task.Factory.StartNew(() => Get(method, tracking));

    public IQueryable<T> GetAll(bool tracking = true) => tracking ? Table.AsQueryable() : Table.AsNoTracking();
    public async Task<IQueryable<T>> GetAllAsync(bool tracking = true) => await Task.Factory.StartNew(() => GetAll(tracking));

    public IQueryable<T> GetWhere(Expression<Func<T, bool>> method, bool tracking = true)
    {
        var models = tracking ? Table.AsQueryable() : Table.AsNoTracking();

        return Table.Where(method);
    }
    public async Task<IQueryable<T>> GetWhereAsync(Expression<Func<T, bool>> method, bool tracking = true) => await Task.Factory.StartNew(() => GetWhere(method, tracking));
}
