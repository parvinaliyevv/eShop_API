namespace eShop.Application.MapperProfiles;

public class ProductProfile: Profile
{
	public ProductProfile()
	{
		CreateMap<Product, ProductViewModel>()
            .ForMember(dest => dest.CategoryName, opt => opt.MapFrom((src, dest) => src.Category.Name))
            .ReverseMap();

		CreateMap<CreateProductViewModel, Product>()
           .ForMember(dest => dest.CategoryId, opt => opt.MapFrom((src, dest) => Guid.TryParse(src.CategoryId, out Guid guid) ? guid : Guid.Empty))
            .ReverseMap();

		CreateMap<UpdateProductViewModel, Product>()
           .ForMember(dest => dest.CategoryId, opt => opt.MapFrom((src, dest) => Guid.TryParse(src.CategoryId, out Guid guid) ? guid : Guid.Empty))
            .ReverseMap();
	}
}
