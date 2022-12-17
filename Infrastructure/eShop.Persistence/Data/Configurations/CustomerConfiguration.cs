namespace eShop.Persistence.Data.Configurations;

public class CustomerConfiguration : IEntityTypeConfiguration<Customer>
{
    public void Configure(EntityTypeBuilder<Customer> builder)
    {
        var customer = new Customer()
        {
            Id = Guid.NewGuid(),
            CreatedDateTime = DateTime.Now,
            UpdatedDateTime = DateTime.Now,
            Name = "John",
            Surname = "Doe"
        };

        builder.HasData(customer);
    }
}
