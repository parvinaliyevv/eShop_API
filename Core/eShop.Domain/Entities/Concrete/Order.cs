namespace eShop.Domain.Entities.Concrete;

public class Order: BaseEntity
{
    public Guid? CustomerId { get; set; }
    public string Address { get; set; }
    public string Description { get; set; }

    public virtual Customer? Customer { get; set; }
    public virtual ICollection<ProductOrder> ProductOrders { get; set; }
}
