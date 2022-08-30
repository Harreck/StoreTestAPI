namespace TiendaProject.Models;

public class Product
{
    public string Title { get; init; }
    public string Description { get; init; }
    public decimal Price { get; init; }
    public Guid Id { get; init; }
    public string FormattedPrice => Price.ToString("C");
}