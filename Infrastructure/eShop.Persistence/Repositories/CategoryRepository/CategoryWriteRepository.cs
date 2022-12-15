namespace eShop.Persistence.Repositories.CategoryRepository;

public class CategoryWriteRepository : WriteRepository<Category>, ICategoryWriteRepository
{
    public CategoryWriteRepository(AppDbContext dbContext) : base(dbContext) { }
}
