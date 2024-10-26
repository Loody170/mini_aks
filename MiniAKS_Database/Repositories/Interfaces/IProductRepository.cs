using MiniAKS_Database.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniAKS_Database.Repositories.Interfaces
{
    public interface IProductRepository
    {

        public Product GetProduct(Guid id);
        public ICollection<Product> GetProducts();
        public ICollection<ProductItem> GetProductItems(Guid id);


    }
}
