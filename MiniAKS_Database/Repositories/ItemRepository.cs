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
    public class ItemRepository : IItemRepository
    {
        private readonly MiniAKSDbContext _context;
        public ItemRepository(MiniAKSDbContext context)
        {          
            _context = context;
        }
        public Item GetItem(Guid id)
        {
            return _context.Items.Find(id); 
        }

        public ICollection<Item> GetItems()
        {
            return _context.Items.ToList();
        }

        public ICollection<Product> GetProductsByItemId(Guid id)
        {
            return _context.ProductItems.Where(pi => pi.ItemId == id)
                .Select(pi => pi.Product)
                .ToList();
                  
        }
    }
}
