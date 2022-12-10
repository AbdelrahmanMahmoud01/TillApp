namespace TillApp.Server.Services.ProductsServices;

public class ProductService : IProductsService
{
    List<Product> _products;

    public ProductService()
    {
        _products = new List<Product>()
        {
            new Product{Id=1,Name = "Pepsi" ,Price =6 ,Image = "pepsi.jpg"},
            new Product{Id=2,Name = "CocaCola" ,Price =6,Image ="coke.jpg"},
            new Product{Id=3,Name = "spirte" ,Price =6 ,Image = "spirte.jpg" },
            new Product{Id=4,Name = "miranda" ,Price =6 ,Image = "miranda.jpg"},
            new Product{Id=5,Name = "Tea" ,Price =5 ,Image = "tea.jpg"},
            new Product{Id=6,Name = "Lemon" ,Price =8 ,Image = "lemon.jpg"},
            new Product{Id=7,Name = "Coffe" ,Price =8 ,Image = "lemon.jpg"},
            new Product{Id=8,Name = "Amestile" ,Price =8 ,Image = "lemon.jpg"}
        };
    }
    public IEnumerable<Product> GetProducts() => _products.ToList();

    public Product GetProductById(int id)
    {
        Product product = _products.FirstOrDefault(x => x.Id == id) ?? new Product();

        return product;
    }
}

