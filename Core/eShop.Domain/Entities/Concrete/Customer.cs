namespace eShop.Domain.Entities.Concrete;

public class Customer: BaseEntity
{
    public string Name { get; set; }
    public string Surname { get; set; }

    public virtual ICollection<Order> Orders { get; set; }
}
