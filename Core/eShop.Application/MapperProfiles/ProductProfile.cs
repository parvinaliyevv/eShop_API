namespace eShop.Application.MapperProfiles;

public class ProductProfile: Profile
{
	public ProductProfile()
	{
		CreateMap<Product, ProductDto>().ReverseMap();

		CreateMap<CreateProductDto, Product>()
           .ForMember(dest => dest.CategoryId, opt => opt.MapFrom((src, dest) => Guid.TryParse(src.CategoryId, out Guid guid) ? guid : Guid.Empty))
            .ReverseMap();

		CreateMap<UpdateProductDto, Product>()
           .ForMember(dest => dest.CategoryId, opt => opt.MapFrom((src, dest) => Guid.TryParse(src.CategoryId, out Guid guid) ? guid : Guid.Empty))
            .ReverseMap();
	}
}
