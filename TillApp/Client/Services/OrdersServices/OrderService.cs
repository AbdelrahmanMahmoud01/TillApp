namespace TillApp.Client.Services.OrdersServices;

public class OrderService : IOrderService
{
    private readonly HttpClient _httpClient;
    private readonly IToastService _toastService;
    public event Action OnChange;

    public OrderService(HttpClient httpClient, IToastService toastService)
    {
        _httpClient = httpClient;
        _toastService = toastService;
    }

    public async Task<Order> GetOrderByIdAsync(int id)
    {
        return await _httpClient.GetFromJsonAsync<Order>($"api/orders/{id}") ?? new Order();
    }

    public async Task<IEnumerable<Order>> GetOrdersAsync()
    {
        return await _httpClient.GetFromJsonAsync<IEnumerable<Order>>("api/orders") ?? new List<Order>();
    }

    public async Task MarkOrderAsPaidAsync(Order order)
    {
        var result = await _httpClient.PostAsJsonAsync($"api/orders/MarkOrderAsPaid",order);

        if (result.StatusCode == System.Net.HttpStatusCode.OK)
        {
            _toastService.ShowSuccess("Order marked as paid");
            return;
        }

        _toastService.ShowError("Could not mark order as paid");
        
    }
}
