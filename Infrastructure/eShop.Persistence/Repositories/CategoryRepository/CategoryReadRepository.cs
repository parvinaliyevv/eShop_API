namespace eShop.Persistence.Repositories.CategoryRepository;

public class CategoryReadRepository : ReadRepository<Category>, ICategoryReadRepository
{
    public CategoryReadRepository(AppDbContext dbContext) : base(dbContext) { }
}
