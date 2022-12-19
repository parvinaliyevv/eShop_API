namespace eShop.Persistence.Data.Configurations;

public class CategoryConfiguration : IEntityTypeConfiguration<Category>
{
    public static readonly Guid categoryId = Guid.NewGuid();

    public void Configure(EntityTypeBuilder<Category> builder)
    {
        var category = new Category()
        {
            Id = categoryId,
            CreatedDateTime = DateTime.Now,
            UpdatedDateTime = DateTime.Now,
            Name = "Smartphone"
        };

        builder.HasData(category);
    }
}
