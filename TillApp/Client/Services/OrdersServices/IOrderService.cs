namespace TillApp.Client.Services.OrdersServices;

public interface IOrderService
{
    Task<IEnumerable<Order>> GetOrdersAsync();
    Task<Order> GetOrderByIdAsync(int id);
    Task MarkOrderAsPaidAsync(Order order);
    event Action OnChange;

}
