using MiniAKS_Database.Database;
using MiniAKS_Database.Models;
using MiniAKS_Database.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniAKS_Database.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private readonly MiniAKSDbContext _context;
        public OrderRepository(MiniAKSDbContext context)
        {
            _context = context;
        }

        public void CreateOrder(Order order)
        {
            _context.Orders.Add(order);
            _context.SaveChanges();
        }

        public Order GetOrder(Guid id)
        {
            return _context.Orders.Find(id);
        }

        public ICollection<Order> GetOrders()
        {
            return _context.Orders.ToList();
        }

        public ICollection<Product> GetProductsForOrder(Guid orderId)
        {
            return _context.OrderProducts.Where(op => op.OrderId == orderId)
                .Select(op => op.Product)
                .ToList(); 
        }
    }
}
