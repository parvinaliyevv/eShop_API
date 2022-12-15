namespace eShop.Persistence.Repositories.OrderRepository;

public class OrderReadRepository : ReadRepository<Order>, IOrderReadRepository
{
    public OrderReadRepository(AppDbContext dbContext) : base(dbContext) { }
}
