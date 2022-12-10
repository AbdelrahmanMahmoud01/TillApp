namespace TillApp.Client.Services.CartServices;

public interface ICartService
{
    event Action OnChange;
    Task AddToCart(CartItem item);
    Task<List<CartItem>> GetCartItems();
    Task DeleteItem(CartItem item);
    Task EmptyCart();
    Task IncrementItem(CartItem item);
    Task DecrementItem(CartItem item);
    Task UpdateItemQuantity(CartItem item);
    Task SubmitOrder(string orderName);
}
