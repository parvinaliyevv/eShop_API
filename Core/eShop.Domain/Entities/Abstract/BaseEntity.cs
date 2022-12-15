namespace eShop.Domain.Entities.Abstract;

public class BaseEntity
{
    public Guid Id { get; set; }
    public DateTime CreatedDateTime { get; set; }
    public DateTime UpdatedDateTime { get; set; }
}
