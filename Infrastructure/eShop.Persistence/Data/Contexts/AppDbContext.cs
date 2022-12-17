namespace eShop.Persistence.Data.Contexts;

public class AppDbContext: DbContext
{
    public DbSet<Category> Categories { get; set; }
    public DbSet<Customer> Customers { get; set; }
    public DbSet<Product> Products { get; set; }
    public DbSet<Order> Orders { get; set; }
    public DbSet<ProductOrder> ProductOrders { get; set; }


    public AppDbContext(DbContextOptions options): base(options) { }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new OrderConfiguration());
        modelBuilder.ApplyConfiguration(new ProductConfiguration());
        modelBuilder.ApplyConfiguration(new CustomerConfiguration());
        modelBuilder.ApplyConfiguration(new CategoryConfiguration());
        modelBuilder.ApplyConfiguration(new ProductOrderConfiguration());
    }

    public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        var entries = ChangeTracker.Entries<BaseEntity>();

        foreach (var item in entries)
        {
            if (item.State == EntityState.Unchanged)
            {
                item.Entity.CreatedDateTime = DateTime.Now;
                item.Entity.UpdatedDateTime = DateTime.Now;
            }
            else if (item.State == EntityState.Modified)
            {
                item.Entity.UpdatedDateTime = DateTime.Now;
            }
        }

        return base.SaveChangesAsync(cancellationToken);
    }
}
