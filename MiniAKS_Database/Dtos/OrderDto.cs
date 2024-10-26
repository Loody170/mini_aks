using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniAKS_Database.Dtos
{
    public class OrderDto
    {
        //public Guid Id { get; set; }
        public string OrderNumber { get; set; }
        public string SalesChannel { get; set; }
        public DateTime PlacedOn { get; set; }
        public DateTime PrintedOn { get; set; }
        public DateTime? CompletedOn { get; set; }
        public ICollection<OrderProductDto> OrderProducts { get; set; }
    }
}
