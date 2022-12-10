namespace TillApp.Server.Services.OrderServices;

public interface IOrderService
{
    Task<Order> CreateOrderAsync(Order order);
    Task<IEnumerable<Order>> GetNonPaidOrdersAsync();
    Task<bool> ChangeNonPaidOrderStatus(Order order);
    Task<IEnumerable<Order>> GetAllOrdersAsync();
    Task<Order> GetOrderDetails(int orderId);
}
