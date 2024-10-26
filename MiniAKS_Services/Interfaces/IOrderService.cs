using MiniAKS_Database.Dtos;
using MiniAKS_Database.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniAKS_Services.Interfaces
{
    public interface IOrderService
    {
        OrderDto GetOrder(Guid id);
        ICollection<OrderDto> GetOrders();
        ICollection<ProductDto> GetProductsForOrder(Guid orderId);
        bool CreateOrder(OrderDto orderDto);
    }
}
