using MiniAKS_Database.Database;
using MiniAKS_Database.Models;
using MiniAKS_Database.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniAKS_Database.Repositories
{
    public class SalesChannelRepository : ISalesChannelRepository
    {
        private readonly MiniAKSDbContext _context;

        public SalesChannelRepository(MiniAKSDbContext context)
        {
            _context = context;
        }

        public SalesChannel GetSalesCannelByName(string name)
        {
            return _context.SalesChannels.Where(sc => sc.Name == name).FirstOrDefault();
        }

        public SalesChannel GetSalesChannel(Guid id)
        {
            return _context.SalesChannels.Find(id);
        }

        public ICollection<SalesChannel> GetSalesChannels()
        {
            return _context.SalesChannels.ToList();
        }

        public bool isSalesChannelActive(Guid id)
        {
            return _context.SalesChannels
        .Where(sc => sc.Id == id)
        .Select(sc => sc.IsActive)
        .FirstOrDefault();
        }
    }
}
