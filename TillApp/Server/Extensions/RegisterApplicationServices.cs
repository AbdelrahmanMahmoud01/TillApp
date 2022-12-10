namespace TillApp.Server.Extensions;

public static class RegisterApplicationServices
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContextPool<AppDbContext>(options =>
        {
            options.UseSqlServer(configuration.GetConnectionString("sqlcon"));
        });

        services.AddScoped<IProductsService, ProductService>();
        services.AddScoped<IOrderService, OrderService>();
        services.AddCors(policy =>
        {
            policy.AddPolicy("CorsPolicy", opt => opt
                .AllowAnyOrigin()
                .AllowAnyHeader()
                .AllowAnyMethod());
        });

        return services;
    }
}
