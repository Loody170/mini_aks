using MiniAKS_Database.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniAKS_Services.Interfaces
{
    public interface ISalesChannelService
    {
        public SalesChannel GetSalesChannel(Guid id);
        public SalesChannel GetSalesCannelByName(string name);
        public ICollection<SalesChannel> GetSalesChannels();
        public bool isSalesChannelActive(Guid id);
    }
}
