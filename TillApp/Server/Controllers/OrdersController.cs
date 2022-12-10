namespace TillApp.Server.Controllers;

public class OrdersController : BaseApiController
{
    private readonly IOrderService _orderService;

    public OrdersController(IOrderService orderService)
    {
        _orderService = orderService;
    }

    [HttpPost]
    public async Task<IActionResult> Post([FromBody] Order order)
    {
        if (order is null)
            return BadRequest();

        await _orderService.CreateOrderAsync(order);

        return Ok();
    }

    [HttpGet]
    public async Task<IActionResult> Get()
    {
        var orders = await _orderService.GetAllOrdersAsync();
        return Ok(orders);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Order>> Get(int id)
    {
        if (id <= 0)
            return NotFound();

        var orderDetails = await _orderService.GetOrderDetails(id);

        if (orderDetails is null)
            return NotFound();
        
        return Ok(orderDetails);
    }

    [HttpPost]
    public async Task<IActionResult> MarkOrderAsPaid([FromBody] Order order)
    {
        if (order is null || !order.OrderItems.Any())
            return BadRequest();

        var isOrderMarked = await _orderService.ChangeNonPaidOrderStatus(order);

        return isOrderMarked ? Ok() : BadRequest();
    }
}
