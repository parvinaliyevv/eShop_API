namespace eShop.Persistence.Data.Configurations;

public class OrderConfiguration : IEntityTypeConfiguration<Order>
{
    public static readonly Guid orderId = Guid.NewGuid();

    public void Configure(EntityTypeBuilder<Order> builder)
    {
        builder.HasOne(o => o.Customer)
            .WithMany(c => c.Orders)
            .HasForeignKey(o => o.CustomerId)
            .OnDelete(DeleteBehavior.SetNull);

        var order = new Order() // CategoryId in migration file
        {
            Id = orderId,
            CreatedDateTime = DateTime.Now,
            UpdatedDateTime = DateTime.Now,
            Address = "(217) 348-8633\r\n1418 6th St\r\nCharleston, Illinois(IL), 61920",
            Description = "Iphone 11",
            CustomerId = CustomerConfiguration.customerId
        };

        builder.HasData(order);
    }
}
