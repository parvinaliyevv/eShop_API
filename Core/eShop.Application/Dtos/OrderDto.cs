namespace eShop.Application.Dtos;

public abstract record BaseOrderDto
{
    public string Address { get; set; }
    public string Description { get; set; }
}

public record OrderDto(string CustomerName): BaseOrderDto;

public record CreateOrderDto(string CustomerId) : BaseOrderDto;

public record UpdateOrderDto(string Id, string CustomerId): BaseOrderDto;
