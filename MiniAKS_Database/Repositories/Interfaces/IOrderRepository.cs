using MiniAKS_Database.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniAKS_Database.Repositories.Interfaces
{
    public interface IOrderRepository
    {
        Order GetOrder(Guid id);
        ICollection<Order> GetOrders();
        ICollection<Product> GetProductsForOrder(Guid orderId);
        public void CreateOrder(Order order);
    }
}
