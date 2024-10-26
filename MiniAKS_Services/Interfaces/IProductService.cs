using MiniAKS_Database.Dtos;
using MiniAKS_Database.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniAKS_Services.Interfaces
{
    public interface IProductService
    {
        public ProductDto GetProduct(Guid id);
        public ICollection<ProductDto> GetProducts();
        public ICollection<ProductItem> GetProductItems(Guid id);
        

    }
}
