using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniAKS_Database.Dtos
{
    public class ItemDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public DateTime CreatedDate { get; set; }
        public int HoldingTimeAfterCooking { get; set; }
        public int DrainageTime { get; set; }
        public int PreparationTime { get; set; }
    }
}
