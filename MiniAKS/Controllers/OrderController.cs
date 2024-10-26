using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MiniAKS_Database.Dtos;
using MiniAKS_Database.Models;
using MiniAKS_Database.Repositories.Interfaces;
using MiniAKS_Services.Interfaces;

namespace MiniAKS.Controllers
{
    [Route("api/[controller]")]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _orderService;
        private readonly ILogger<OrderController> _logger;
        public OrderController(IOrderService orderService, ILogger<OrderController> logger)
        {
            _orderService = orderService;
            _logger = logger;


        }

        [HttpGet]
        public IActionResult GetOrders() { 
            var orders = _orderService.GetOrders();
            return Ok(orders);
        }

        [HttpGet("{orderId}")]
        public IActionResult GetOrder(Guid orderId)
        {
            var order = _orderService.GetOrder(orderId);
            return Ok(order);
        }

        [HttpGet("{orderId}/products")]
        public IActionResult GetProductsInAnOrder(Guid orderId) { 
            var products = _orderService.GetProductsForOrder(orderId);
            return Ok(products);
        }

        [HttpPost]
        public IActionResult CreateOrder([FromBody] OrderDto order)
        {
           if(order == null)
            {
                return BadRequest();
            }
            _logger.LogInformation("Order received");
            var isCreated = _orderService.CreateOrder(order);
            if (isCreated)
            {
                return Ok("Order Created Successfully");
            }
            else
            {
                return BadRequest();
            }

            }
    }
}
