namespace eShop.Persistence.Data.Configurations;

public class ProductConfiguration : IEntityTypeConfiguration<Product>
{
    public static readonly Guid firstProductId = Guid.NewGuid();
    public static readonly Guid secondProductId = Guid.NewGuid();

    public void Configure(EntityTypeBuilder<Product> builder)
    {
        builder.HasOne(p => p.Category)
            .WithMany(c => c.Products)
            .HasForeignKey(p => p.CategoryId)
            .OnDelete(DeleteBehavior.SetNull);

        var products = new List<Product>()
        {
            new Product()
            {
                Id = firstProductId,
                CreatedDateTime = DateTime.Now,
                UpdatedDateTime = DateTime.Now,
                Name = "Iphone 11",
                Description = "128 gb black",
                Price = 1399,
                Stock = 50,
                CategoryId = CategoryConfiguration.categoryId,
                Image = "iphone-11-black.jpg"
            },
            new Product()
            {
                Id = secondProductId,
                CreatedDateTime = DateTime.Now,
                UpdatedDateTime = DateTime.Now,
                Name = "Iphone 11",
                Description = "64 gb white",
                Price = 1199,
                Stock = 50,
                CategoryId = CategoryConfiguration.categoryId,
                Image = "iphone-11-white.jpg"
            },
            new Product()
            {
                Id = Guid.NewGuid(),
                CreatedDateTime = DateTime.Now,
                UpdatedDateTime = DateTime.Now,
                Name = "Iphone 11",
                Description = "128 gb white",
                Price = 1399,
                Stock = 50,
                CategoryId = CategoryConfiguration.categoryId,
                Image = "iphone-11-white.jpg"
            }
        };

        builder.HasData(products);
    }
}
