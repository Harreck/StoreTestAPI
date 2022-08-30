using TiendaProject.Models;

namespace TiendaProject.Services;

public class OrderServices
{
    private static readonly List<Order> _orderList = new List<Order>();
    private readonly ProductServices _productServices;
    public OrderServices(ProductServices productServices)
    {
        _productServices = productServices;
    }
    
    public Order Create(IEnumerable<ProductsIdQuantity> productsQuantities)
    {
       
        var productList = new List<ProductsQuantity>();
        foreach (var productsQuantity in productsQuantities)
        {
            if (productsQuantity.Quantity <= 0)
            {
                throw new InvalidOperationException("Invalid Quantity");
            }
            var product = _productServices.GetProduct(productsQuantity.ProductId);
            productList.Add(new ProductsQuantity(){Product = product, Quantity = productsQuantity.Quantity});
        }

        var order = new Order()
        {
            Id = Guid.NewGuid(), Products = productList
        };
        _orderList.Add(order);
        return order;
    }

    public IEnumerable<Order> GetAll()
    {
        return _orderList;
    }

    public Order GetOrder(Guid id)
    {
        var order = _orderList.Find(i => i.Id == id) ?? throw new KeyNotFoundException("Order Not Found");
        return order;
    }
}
