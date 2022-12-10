
namespace TillApp.Server.Controllers;
public class ProductsController : BaseApiController
{
    private readonly IProductsService _productsService;

    public ProductsController(IProductsService productsService)
    {
        _productsService = productsService;
    }

    public IActionResult Index()
    {
        var products = _productsService.GetProducts();
        return Ok(products);
    }

    [HttpGet("{id}")]
    public ActionResult<Product> GetProduct(int id)
    {
        return Ok( _productsService.GetProductById(id));
    }
}
