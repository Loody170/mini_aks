using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniAKS_Database.Dtos
{
    public class OrderProductDto
    {
        public Guid ProductId { get; set; }
        public int Quantity { get; set; }
        public List<string> Customizations { get; set; }
    }
}
