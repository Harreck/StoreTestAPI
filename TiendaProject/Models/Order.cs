namespace TiendaProject.Models;

public class Order
{
    public Guid Id { get; init; }
    public IEnumerable<ProductsQuantity> Products { get; init; }
    public decimal Price => Products.Sum(pq => pq.Product.Price * pq.Quantity);
    public string FormattedPrice => Price.ToString("C");
}