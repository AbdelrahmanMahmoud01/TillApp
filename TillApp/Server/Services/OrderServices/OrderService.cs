namespace TillApp.Server.Services.OrderServices;

public class OrderService : IOrderService
{
    private readonly AppDbContext _context;

    public OrderService (AppDbContext context)
    {
        _context = context;
    }

    public async Task<bool> ChangeNonPaidOrderStatus(Order order)
    {
        order.IsPaid = true;
        _context.Entry(order).State = EntityState.Modified;
        var isStatusChanged = await _context.SaveChangesAsync();
        return isStatusChanged > 0;
    }

    public async Task<Order> CreateOrderAsync(Order order)
    {
        try
        {

            var result = await _context.Orders.AddAsync(order);
            await _context.OrderItems.AddRangeAsync(order.OrderItems);
            await _context.SaveChangesAsync();
            return order;
        }
        catch (Exception)
        {
            throw;
        }
    }

    public async Task<IEnumerable<Order>> GetAllOrdersAsync()
    {
        var orders = await _context.Orders.ToListAsync() ?? new List<Order>();
        return orders;
    }

    public async Task<IEnumerable<Order>> GetNonPaidOrdersAsync()
    {
        var nonPaidOrders = await _context.Orders.Where(o => o.IsPaid == false).ToListAsync();

        return nonPaidOrders;
    }

    public async Task<Order> GetOrderDetails(int orderId)
    {
        var orderDetails = await _context.Orders.
                           Include(x=>x.OrderItems).
                           FirstOrDefaultAsync(x=>x.Id == orderId);

        return orderDetails;
    }
}
