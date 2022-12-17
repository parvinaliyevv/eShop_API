namespace eShop.Application.Services;

public static class ContainerRegistrationService
{
    public static void ApplicationRegister(this IServiceCollection services)
    {
        var currentAssembly = Assembly.GetExecutingAssembly();

        services.AddMediatR(currentAssembly);
        services.AddAutoMapper(currentAssembly);
        services.AddFluentValidation(x => x.RegisterValidatorsFromAssembly(currentAssembly));
    }
}
