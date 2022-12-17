namespace eShop.Application.Dtos;

public abstract record BaseOrderDto
{
    public string Address { get; set; }
    public string Description { get; set; }
}

public record OrderDto(string Id, string CustomerName): BaseOrderDto
{
    public string? CustomerName { get; set; }
    public ICollection<ProductDto> Products { get; set; } = new List<ProductDto>();
}

public record CreateOrderDto(string CustomerId) : BaseOrderDto;

public record UpdateOrderDto(string Id, string CustomerId) : BaseOrderDto;
