namespace TillApp.Client.Extensions;

public static class RegisterClientServices
{
    public static IServiceCollection AddClientServices(this IServiceCollection services)
    {
        services.AddScoped<IProductService, ProductService>();
        services.AddScoped<ICartService, CartService>();
        services.AddScoped<IOrderService, OrderService>();
        services.AddBlazoredLocalStorage();
        services.AddBlazoredToast();
        services.AddBlazoredModal();
        return services;
    }
}
