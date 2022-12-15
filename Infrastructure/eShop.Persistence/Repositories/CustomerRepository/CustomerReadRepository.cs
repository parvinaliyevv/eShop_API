namespace eShop.Persistence.Repositories.CustomerRepository;

public class CustomerReadRepository : ReadRepository<Customer>, ICustomerReadRepository
{
    public CustomerReadRepository(AppDbContext dbContext) : base(dbContext) { }
}
