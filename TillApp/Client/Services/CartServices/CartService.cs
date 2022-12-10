namespace TillApp.Client.Services.CartServices;

public class CartService : ICartService
{
    private readonly ILocalStorageService _localStorage;
    private readonly IToastService _toastService;
    private readonly HttpClient _httpClient;

    public event Action OnChange;

    public CartService(
        ILocalStorageService localStorage,
        IToastService toastService,
        IProductService productService,
        HttpClient httpClient)
    {
        _localStorage = localStorage;
        _toastService = toastService;
        _httpClient = httpClient;
    }

    public async Task AddToCart(CartItem item)
    {

        var cart = await _localStorage.GetItemAsync<List<CartItem>>("cart") ?? new List<CartItem>();

        var sameItem = cart.Find(x => x.ProductId == item.ProductId);

        if (sameItem == null)
            cart.Add(item);

        else
            sameItem.Quantity += item.Quantity;

        await _localStorage.SetItemAsync("cart", cart);

        _toastService.ShowSuccess(item.ProductTitle, "Added to cart");

        OnChange.Invoke();
    }
    
    public async Task IncrementItem(CartItem item)
    {

        var cart = await _localStorage.GetItemAsync<List<CartItem>>("cart") ?? new List<CartItem>();

        var sameItem = cart.Find(x => x.ProductId == item.ProductId);

        if (sameItem == null)
            cart.Add(item);

        else
            sameItem.Quantity += 1;

        await _localStorage.SetItemAsync("cart", cart);

        OnChange.Invoke();
    }

    public async Task DecrementItem(CartItem item)
    {
        var cart = await _localStorage.GetItemAsync<List<CartItem>>("cart") ?? new List<CartItem>();

        var sameItem = cart.Find(x => x.ProductId == item.ProductId);

        if (sameItem is not null && sameItem.Quantity > 1)
            sameItem.Quantity -= 1;

        await _localStorage.SetItemAsync("cart", cart);

        OnChange.Invoke();
    }

    public async Task<List<CartItem>> GetCartItems()
    {
        var cart = await _localStorage.GetItemAsync<List<CartItem>>("cart") ?? new List<CartItem>();

        return cart;
    }

    public async Task UpdateItemQuantity(CartItem item)
    {
        var cart = await _localStorage.GetItemAsync<List<CartItem>>("cart") ?? new List<CartItem>();

        var sameItem = cart.Find(x => x.ProductId == item.ProductId);

        if (sameItem is not null && item.Quantity >0)
            sameItem.Quantity = item.Quantity;


        await _localStorage.SetItemAsync("cart", cart);

        OnChange.Invoke();
    }

    public async Task DeleteItem(CartItem item)
    {
        var cart = await _localStorage.GetItemAsync<List<CartItem>>("cart");
        if (cart == null)
        {
            return;
        }

        var cartItem = cart.Find(x => x.ProductId == item.ProductId);
        cart.Remove(cartItem);

        await _localStorage.SetItemAsync("cart", cart);
        OnChange.Invoke();
    }

    public async Task EmptyCart()
    {
        await _localStorage.RemoveItemAsync("cart");
        OnChange.Invoke();
    }
    
    public async Task SubmitOrder(string orderName)
    {
        var cartItems = await _localStorage.GetItemAsync<List<CartItem>>("cart");

        if (cartItems is null || cartItems.Count()<=0)
        {
            _toastService.ShowError("Cart cannot be empty");
            return;
        }

        foreach (var item in cartItems)
        {
            if (item.Quantity <= 0)
            {
                _toastService.ShowError("Product quantity cannot be 0");
                return;
            }
        }

        var cartTotalPirce = cartItems.Where(x => x.ItemTotalPrice > 0);
        var totalAmount = cartTotalPirce.Sum(x => x.ItemTotalPrice);
        var orderitemsList = new List<OrderItem>();

        foreach (var cartItem in cartItems)
        {
            var orderItem = new OrderItem();
            orderItem.ItemName = cartItem.ProductTitle;
            orderItem.Money = cartItem.ItemTotalPrice;
            orderItem.Quantity = cartItem.Quantity;
            orderitemsList.Add(orderItem);
        }

        var Order = new Order
        {
            IsPaid = false,
            OrderName = orderName,
            Money = totalAmount,
            OrderItems = orderitemsList
        };

        var result = await _httpClient.PostAsJsonAsync("api/orders/post",Order);
        if (result.StatusCode != System.Net.HttpStatusCode.OK)
        {
            _toastService.ShowError("Some errors occuerd while submiting your order please try again");
            return;
        }
        await _localStorage.RemoveItemAsync("cart");
        _toastService.ShowSuccess("Thanks for ordering from 3S-POS");
        OnChange.Invoke();
    }
}