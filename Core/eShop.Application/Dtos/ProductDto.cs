namespace eShop.Application.Dtos;

public abstract record BaseProductDto
{
    public string Name { get; set; }
    public string Description { get; set; }
    public double Price { get; set; }
    public int Stock { get; set; }
}

public record ProductDto(string Id, string CategoryName): BaseProductDto
{
    public string ImageUrl { get; set; }
}

public record CreateProductDto(string CategoryId, IFormFile Image) : BaseProductDto;

public record UpdateProductDto(string Id, string CategoryId, IFormFile Image) : BaseProductDto;
