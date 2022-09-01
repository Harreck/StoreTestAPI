using TiendaProject.Models;

namespace TiendaProject.Services;

public class ProductServices
{

    private static readonly List<Product> _productsList = new List<Product>();

    public IEnumerable<Product> GetAll()
    {
        return _productsList;
    }

    public Product Create(string title, string description, decimal price)
    {
        if (price <= 0)
        {
            throw new InvalidOperationException("Invalid Price");
        }

        var productsCreate = new Product()
        {
            Title = title, Description = description, Id = Guid.NewGuid(), Price = price
        };
        _productsList.Add(productsCreate);
        
        return productsCreate;
    }

    public Product GetProduct(Guid id)
    {
     var product = _productsList.Find(i => i.Id == id)?? throw new KeyNotFoundException("Product Not Found");
     return product;

    }

    public void Delete(Guid id)
    {
        _productsList.RemoveAt(_productsList.FindIndex(i => i.Id == id));
    }

    public IEnumerable<Product> SearchProduct(string searchProduct)
    {
        var searchProductLower = searchProduct.ToLowerInvariant(); 
        var product = _productsList.FindAll(i => i.Title.ToLowerInvariant().Contains(searchProductLower)
                                                  || i.Description.ToLowerInvariant().Contains(searchProductLower));
        return product;
    }
    
}

