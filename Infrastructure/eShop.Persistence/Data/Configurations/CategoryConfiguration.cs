namespace eShop.Persistence.Data.Configurations;

public class CategoryConfiguration : IEntityTypeConfiguration<Category>
{
    public void Configure(EntityTypeBuilder<Category> builder)
    {
        var category = new Category()
        {
            Id = Guid.NewGuid(),
            CreatedDateTime = DateTime.Now,
            UpdatedDateTime = DateTime.Now,
            Name = "Smartphone"
        };

        builder.HasData(category);
    }
}
