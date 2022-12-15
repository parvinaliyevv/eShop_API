namespace eShop.Domain.Entities.Concrete;

public class Product: BaseEntity
{
    public Guid? CategoryId { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public double Price { get; set; }
    public int Stock { get; set; }

    public virtual Category? Category { get; set; }
    public virtual ICollection<ProductOrder> ProductOrders { get; set; }
}
