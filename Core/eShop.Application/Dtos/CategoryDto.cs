namespace eShop.Application.Dtos;

public abstract record BaseCategoryDto
{
    public string Name { get; set; }
}

public record CategoryDto : BaseCategoryDto;

public record CreateCategoryDto : BaseCategoryDto;

public record UpdateCategoryDto(string Id) : BaseCategoryDto;
