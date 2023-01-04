namespace eShop.Persistence.Services;

public static class ContainerRegistrationService
{
    public static void PersistenceRegister(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<AppDbContext>(options => options.UseSqlServer(configuration.GetConnectionString("SqlServerAuth")));

        services.AddScoped<IUserManager, UserManager>();

        RepositoryRegister(services);
    }

    private static void RepositoryRegister(this IServiceCollection services)
    {
        services.AddScoped<IProductReadRepository, ProductReadRepository>();
        services.AddScoped<IOrderReadRepository, OrderReadRepository>();
        services.AddScoped<ICustomerReadRepository, CustomerReadRepository>();
        services.AddScoped<ICategoryReadRepository, CategoryReadRepository>();

        services.AddScoped<IProductWriteRepository, ProductWriteRepository>();
        services.AddScoped<IOrderWriteRepository, OrderWriteRepository>();
        services.AddScoped<ICustomerWriteRepository, CustomerWriteRepository>();
        services.AddScoped<ICategoryWriteRepository, CategoryWriteRepository>();
    }
}
