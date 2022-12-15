namespace eShop.Application.MapperProfiles;

public class CategoryProfile: Profile
{
	public CategoryProfile()
	{
        CreateMap<CategoryViewModel, Category>().ReverseMap();
        CreateMap<CreateCategoryViewModel, Category>().ReverseMap();
        CreateMap<UpdateCategoryViewModel, Category>().ReverseMap();
    }
}
