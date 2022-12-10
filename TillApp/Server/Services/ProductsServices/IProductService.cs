namespace TillApp.Server.Services.ProductsServices;

public interface IProductsService
{
    IEnumerable<Product> GetProducts();
    Product GetProductById(int id);
}

