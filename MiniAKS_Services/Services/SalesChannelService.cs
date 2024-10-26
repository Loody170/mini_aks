using MiniAKS_Database.Models;
using MiniAKS_Database.Repositories.Interfaces;
using MiniAKS_Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniAKS_Services.Services
{
    public class SalesChannelService : ISalesChannelService
    {
        private readonly ISalesChannelRepository _salesChannelRepository;

        public SalesChannelService(ISalesChannelRepository salesChannelRepository)
        {
            _salesChannelRepository = salesChannelRepository;
        }

        public SalesChannel GetSalesCannelByName(string name)
        {
            return _salesChannelRepository.GetSalesCannelByName(name);
        }

        public SalesChannel GetSalesChannel(Guid id)
        {
            return _salesChannelRepository.GetSalesChannel(id);
        }

        public ICollection<SalesChannel> GetSalesChannels()
        {
            return _salesChannelRepository.GetSalesChannels();
        }

        public bool isSalesChannelActive(Guid id)
        {
            return _salesChannelRepository.isSalesChannelActive(id);
        }
    }
}
