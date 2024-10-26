using Microsoft.EntityFrameworkCore;
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
    public class ProductRepository : IProductRepository
    {
        private readonly MiniAKSDbContext _context;
        public ProductRepository(MiniAKSDbContext context)
        {
            _context = context;
        }
        public Product GetProduct(Guid id)
        {
            return _context.Products.Find(id);
        }

        public ICollection<ProductItem> GetProductItems(Guid id)
        {
            return _context.ProductItems
                 .Include(pi => pi.Product) 
                 .Include(pi => pi.Item)  
                 .Where(pi => pi.ProductId == id).ToList();
        }

        public ICollection<Product> GetProducts()
        {
            return _context.Products.ToList();
        }
    }
}
