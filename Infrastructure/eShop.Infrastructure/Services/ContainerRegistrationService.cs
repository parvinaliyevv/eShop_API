namespace eShop.Infrastructure.Services;

public static class ContainerRegistrationService
{
    public static void InfrastructureRegister(this IServiceCollection services)
    {
        services.AddAutoMapper(typeof(ProductProfile));
    }
}
