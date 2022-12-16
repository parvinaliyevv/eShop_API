namespace eShop.Application.MapperProfiles;

public class CustomerProfile: Profile
{
	public CustomerProfile()
	{
        CreateMap<CustomerDto, Customer>().ReverseMap();
        CreateMap<CreateCustomerDto, Customer>().ReverseMap();
        CreateMap<UpdateCustomerDto, Customer>().ReverseMap();
    }
}
