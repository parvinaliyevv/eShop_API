namespace eShop.Application.MapperProfiles;

public class CustomerProfile: Profile
{
	public CustomerProfile()
	{
        CreateMap<CustomerViewModel, Customer>().ReverseMap();
        CreateMap<CreateCustomerViewModel, Customer>().ReverseMap();
        CreateMap<UpdateCustomerViewModel, Customer>().ReverseMap();
    }
}
