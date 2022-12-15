namespace eShop.Application.ViewModels;

public abstract record BaseProductViewModel
{
    public string Name { get; set; }
    public string Description { get; set; }
    public double Price { get; set; }
    public int Stock { get; set; }
}

public record ProductViewModel(string CategoryName): BaseProductViewModel;

public record CreateProductViewModel(string CategoryId): BaseProductViewModel;

public record UpdateProductViewModel(string Id, string CategoryId): BaseProductViewModel;
