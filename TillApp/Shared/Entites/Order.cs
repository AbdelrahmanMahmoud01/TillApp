namespace TillApp.Shared.Entites;
public class Order
{
    public int Id { get; set; }
    public string? OrderName { get; set; }
    public decimal Money { get; set; }
    public bool IsPaid { get; set; }
    public IEnumerable<OrderItem> OrderItems { get; set; }
}
