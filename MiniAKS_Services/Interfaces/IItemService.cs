using MiniAKS_Database.Dtos;
using MiniAKS_Database.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniAKS_Services.Interfaces
{
    public interface IItemService
    {
        public ItemDto GetItem(Guid id);
        public ICollection<ItemDto> GetItems();
        public ICollection<ProductDto> GetProductsByItemId(Guid id);
    }
}
