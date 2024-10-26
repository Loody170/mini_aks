﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniAKS_Database.Models
{
    public class StationQueue
    {
        public Guid Id { get; set; }
        public Guid StationId { get; set; }
        public Station Station { get; set; }
        public Guid ItemId { get; set; }
        public Item Item { get; set; }
        public int Quantity { get; set; }
    }
}
