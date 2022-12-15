namespace eShop.Application.ViewModels;

public abstract record BaseCategoryViewModel
{
    public string Name { get; set; }
}

public record CategoryViewModel : BaseCategoryViewModel;

public record CreateCategoryViewModel : BaseCategoryViewModel;

public record UpdateCategoryViewModel(string Id) : BaseCategoryViewModel;
