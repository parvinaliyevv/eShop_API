namespace eShop.Domain.Entities.Concrete;

public class ProductOrder
{
    public Guid ProductId { get; set; }
    public Product Product { get; set; }

    public Guid OrderId { get; set; }
    public Order Order { get; set; }


    public ProductOrder(Guid productId, Guid orderId)
    {
        ProductId = productId;
        OrderId = orderId;
    }
}
