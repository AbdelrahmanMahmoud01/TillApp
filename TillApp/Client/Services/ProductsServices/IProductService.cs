namespace TillApp.Client.Services;

public interface IProductService
{
    Task<IEnumerable<Product>> GetProductsAsync();
    Task<Product> GetProduct(int id);
}
