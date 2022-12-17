namespace eShop.Application.MapperProfiles;

public class OrderProfile: Profile
{
	public OrderProfile()
	{
        CreateMap<Order, OrderDto>()
            .ForMember(dest => dest.CustomerName, opt => opt.MapFrom(src => $"{src.Customer.Name} {src.Customer.Surname}"))
            .ReverseMap();

        CreateMap<CreateOrderDto, Order>()
            .ForMember(dest => dest.CustomerId, opt => opt.MapFrom((src, dest) => Guid.TryParse(src.CustomerId, out Guid guid) ? guid : Guid.Empty))
            .ReverseMap();

        CreateMap<UpdateOrderDto, Order>()
            .ForMember(dest => dest.CustomerId, opt => opt.MapFrom((src, dest) => Guid.TryParse(src.CustomerId, out Guid guid) ? guid : Guid.Empty))
            .ReverseMap();
    }
}
