using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.Mvc;
using TiendaProject.Models;
using TiendaProject.Services;

namespace TiendaProject.Controllers;

[ApiController]
[Route("[controller]")]
public class ProductsController : ControllerBase
{

    private readonly ILogger<ProductsController> _logger;
    private readonly ProductServices _productServices;

    public ProductsController(ILogger<ProductsController> logger, ProductServices productServices)
    {
        _logger = logger;
        _productServices = productServices;
    }

    [HttpGet("All")]
    public IEnumerable<Product> Get()
    {
        return _productServices.GetAll();
    }

    [HttpPost(Name = "CreateProduct")]
    public Product Create(string title, string description, decimal price)
    {
        return _productServices.Create(title, description, price: price);
    }

    [HttpGet("{id}")]
    public Product GetProduct(Guid id)
    {
        return _productServices.GetProduct(id);
    }

    [HttpDelete(Name = "DeleteProduct")]
    public void Delete(Guid id)
    {
        _productServices.Delete(id);
    }
    [HttpGet("search/{searchProduct}")]
    public IEnumerable<Product> SearchProduct(string searchProduct)
    {
        return _productServices.SearchProduct(searchProduct);
    }
    
    
    
    

}