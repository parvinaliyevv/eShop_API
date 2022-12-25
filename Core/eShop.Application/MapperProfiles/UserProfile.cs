namespace eShop.Application.MapperProfiles;

public class UserProfile: Profile
{
	public UserProfile()
	{
		CreateMap<SignInUserDto, User>().ReverseMap();
		CreateMap<SignUpUserDto, User>().ReverseMap();
	}
}
