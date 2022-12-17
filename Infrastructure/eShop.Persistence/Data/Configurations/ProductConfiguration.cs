namespace eShop.Persistence.Data.Configurations;

public class ProductConfiguration : IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> builder)
    {
        builder.HasOne(p => p.Category)
            .WithMany(c => c.Products)
            .HasForeignKey(p => p.CategoryId)
            .OnDelete(DeleteBehavior.SetNull);

        var products = new List<Product>() // CategoryId in migration file
        {
            new Product()
            {
                Id = Guid.NewGuid(),
                CreatedDateTime = DateTime.Now,
                UpdatedDateTime = DateTime.Now,
                Name = "Iphone 11",
                Description = "128 gb black",
                Price = 1399,
                Stock = 50,
                CategoryId = null
            },
            new Product()
            {
                Id = Guid.NewGuid(),
                CreatedDateTime = DateTime.Now,
                UpdatedDateTime = DateTime.Now,
                Name = "Iphone 11",
                Description = "64 gb white",
                Price = 1199,
                Stock = 50,
                CategoryId = null
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
                CategoryId = null
            }
        };

        builder.HasData(products);
    }
}
