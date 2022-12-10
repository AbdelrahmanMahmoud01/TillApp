namespace TillApp.Client.Services;

public class ProductService :  IProductService
{
    private readonly HttpClient _httpClient;

    public ProductService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<IEnumerable<Product>> GetProductsAsync()
    {
        return await _httpClient.GetFromJsonAsync<IEnumerable<Product>>("api/products");
    }

    public async Task<Product> GetProduct(int id)
    {
        var product = await _httpClient.GetFromJsonAsync<Product>($"api/ProductDetails?id={id}");
        return product;
    }
}
