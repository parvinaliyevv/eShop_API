﻿namespace eShop.Persistence.Services;

public static class ContainerRegistrationService
{
    public static void PersistenceRegister(this IServiceCollection services, IConfiguration _config)
    {
        services.AddDbContext<AppDbContext>(options => options.UseSqlServer(_config.GetConnectionString("Default")));

        services.AddScoped<IProductReadRepository, ProductReadRepository>();
        services.AddScoped<IOrderReadRepository, OrderReadRepository>();
        services.AddScoped<ICustomerReadRepository, CustomerReadRepository>();
        services.AddScoped<ICategoryReadRepository, CategoryReadRepository>();

        services.AddScoped<IProductWriteRepository, ProductWriteRepository>();
        services.AddScoped<IOrderWriteRepository, OrderWriteRepository>();
        services.AddScoped<ICustomerWriteRepository, CustomerWriteRepository>();
        services.AddScoped<ICategoryWriteRepository, CategoryWriteRepository>();

        services.AddScoped<IUserManager, UserManager>();
    }
}
