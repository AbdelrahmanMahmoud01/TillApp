namespace TillApp.Shared.Entites;
public class OrderItem
{
    public int Id { get; set; }
    public int OrderID { get; set; }
    public string? ItemName { get; set; }
    public decimal Money { get; set; }
    public int Quantity { get; set; }

    private decimal _Total;

    public decimal Total
    {
        get { return _Total; }
        set { _Total = Quantity * Money; }
    }

}
