namespace eShop.Application.MapperProfiles;

public class CategoryProfile: Profile
{
	public CategoryProfile()
	{
        CreateMap<CategoryDto, Category>().ReverseMap();
        CreateMap<CreateCategoryDto, Category>().ReverseMap();
        CreateMap<UpdateCategoryDto, Category>().ReverseMap();
    }
}
