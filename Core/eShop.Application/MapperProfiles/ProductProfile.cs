namespace eShop.Application.MapperProfiles;

public class ProductProfile: Profile
{
	public ProductProfile()
	{
		CreateMap<Product, ProductDto>().ReverseMap();

        CreateMap<CreateProductDto, Product>()
           .ForMember(dest => dest.CategoryId, opt => opt.MapFrom((src, dest) => Guid.TryParse(src.CategoryId, out Guid guid) ? guid : Guid.Empty))
           .ForMember(dest => dest.Image, opt => opt.MapFrom((src, dest) =>
           {
               var filename = Path.GetFileNameWithoutExtension(src.Image.FileName);
               var extension = Path.GetExtension(src.Image.FileName);
               return $"{filename}-{DateTime.Now.ToUniversalTime():yyyyMMddHHmmss}{extension}";
           }))
           .ReverseMap();

		CreateMap<UpdateProductDto, Product>()
           .ForMember(dest => dest.CategoryId, opt => opt.MapFrom((src, dest) => Guid.TryParse(src.CategoryId, out Guid guid) ? guid : Guid.Empty))
           .ForMember(dest => dest.Image, opt => opt.MapFrom((src, dest) =>
           {
               var filename = Path.GetFileNameWithoutExtension(src.Image.FileName);
               var extension = Path.GetExtension(src.Image.FileName);
               return $"{filename}-{DateTime.Now.ToUniversalTime():yyyyMMddHHmmss}{extension}";
           }))
           .ReverseMap();
	}
}
