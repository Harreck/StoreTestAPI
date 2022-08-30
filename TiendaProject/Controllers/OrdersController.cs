using System.Security.Cryptography;
using Microsoft.AspNetCore.Mvc;
using TiendaProject.Models;
using TiendaProject.Services;

namespace TiendaProject.Controllers;

[ApiController]
[Route("[controller]")]
public class OrdersController : ControllerBase
{

    private readonly ILogger<OrdersController> _logger;
    private readonly OrderServices _orderServices;

    public OrdersController(ILogger<OrdersController> logger, OrderServices orderServices)
    {
        _logger = logger;
        _orderServices = orderServices;
    }

    [HttpGet("All")]
    public IEnumerable<Order> Get()
    {
        return _orderServices.GetAll();
    }
    [HttpPost(Name = "CreateOrder" )]
    public Order Create(IEnumerable<ProductsIdQuantity> productsIds)
    {
        return _orderServices.Create(productsIds);
    }
    [HttpGet("{id}")]
    public Order GetOrder(Guid id)
    {
        return _orderServices.GetOrder(id);
    }



}