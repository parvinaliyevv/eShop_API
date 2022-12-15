namespace eShop.Persistence.Repositories.CustomerRepository;

internal class CustomerWriteRepository : WriteRepository<Customer>, ICustomerWriteRepository
{
    public CustomerWriteRepository(AppDbContext dbContext) : base(dbContext) { }
}
