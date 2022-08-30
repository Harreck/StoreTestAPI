namespace TiendaProject.Models;

public class ProductsQuantity
{
    public Product Product { get; init; }
    public int Quantity { get; init; }
    public decimal TotalPrice => Quantity * Product.Price;
    public string FormattedTotalPrice => TotalPrice.ToString("C");
}
