namespace eShop.Application.ViewModels;

public abstract record BaseCustomerViewModel
{
    public string Name { get; set; }
    public string Surname { get; set; }
}

public record CustomerViewModel: BaseCustomerViewModel;

public record CreateCustomerViewModel: BaseCustomerViewModel;

public record UpdateCustomerViewModel(string Id): BaseCustomerViewModel;
