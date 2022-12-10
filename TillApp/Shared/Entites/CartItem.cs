namespace TillApp.Shared.Entites;
public class CartItem
{
    public int ProductId { get; set; }
    public string? ProductTitle { get; set; }
    public decimal Price { get; set; }
    public string? Image { get; set; }
    public int Quantity { get; set; }

    private decimal Total;

    public decimal ItemTotalPrice
    {
        get { return Total; }
        set { Total = Price * Quantity; }
    }

}
