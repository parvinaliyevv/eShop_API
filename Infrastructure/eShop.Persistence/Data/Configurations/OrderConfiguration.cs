namespace eShop.Persistence.Data.Configurations;

public class OrderConfiguration : IEntityTypeConfiguration<Order>
{
    public void Configure(EntityTypeBuilder<Order> builder)
    {
        builder.HasOne(o => o.Customer)
            .WithMany(c => c.Orders)
            .HasForeignKey(o => o.CustomerId)
            .OnDelete(DeleteBehavior.SetNull);

        var order = new Order() // CategoryId in migration file
        {
            Id = Guid.NewGuid(),
            CreatedDateTime = DateTime.Now,
            UpdatedDateTime = DateTime.Now,
            Address = "(217) 348-8633\r\n1418 6th St\r\nCharleston, Illinois(IL), 61920",
            Description = "Iphone 11",
            CustomerId = null
        };

        builder.HasData(order);
    }
}
