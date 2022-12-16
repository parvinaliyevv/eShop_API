namespace eShop.Application.Services;

public static class ContainerRegistrationService
{
    public static void PersistenceRegister(this IServiceCollection services)
    {
        services.AddMediatR(typeof(ContainerRegistrationService));
    }
}
