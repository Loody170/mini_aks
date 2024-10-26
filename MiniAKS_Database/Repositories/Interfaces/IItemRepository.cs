using MiniAKS_Database.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniAKS_Database.Repositories.Interfaces
{
    public interface IItemRepository
    {

        public Item GetItem(Guid id);
        public ICollection<Item> GetItems(); 
        public ICollection<Product> GetProductsByItemId(Guid id);
    }
}
