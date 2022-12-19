namespace eShop.Persistence.Data.Configurations;

public class CustomerConfiguration : IEntityTypeConfiguration<Customer>
{
    public static readonly Guid customerId = Guid.NewGuid();

    public void Configure(EntityTypeBuilder<Customer> builder)
    {
        var customer = new Customer()
        {
            Id = customerId,
            CreatedDateTime = DateTime.Now,
            UpdatedDateTime = DateTime.Now,
            Name = "John",
            Surname = "Doe"
        };

        builder.HasData(customer);
    }
}
