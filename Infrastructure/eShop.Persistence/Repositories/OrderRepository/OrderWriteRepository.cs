namespace eShop.Persistence.Repositories.OrderRepository;

public class OrderWriteRepository : WriteRepository<Order>, IOrderWriteRepository
{
    public OrderWriteRepository(AppDbContext dbContext) : base(dbContext) { }
}
