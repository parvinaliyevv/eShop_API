namespace eShop.Application.ViewModels;

public abstract record BaseOrderViewModel
{
    public string Address { get; set; }
    public string Description { get; set; }
}

public record OrderViewModel(string CustomerName): BaseOrderViewModel;

public record CreateOrderViewModel(string CustomerId) : BaseOrderViewModel;

public record UpdateOrderViewModel(string Id, string CustomerId): BaseOrderViewModel;
