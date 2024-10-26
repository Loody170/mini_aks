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
    public class StationQueueRepository : IStationQueueRepository
    {
        private readonly MiniAKSDbContext _context;
        public StationQueueRepository(MiniAKSDbContext context)
        {
            _context = context;
        }
        public void AddStationQueue(StationQueue stationQueue)
        {
            _context.StationQueues.Add(stationQueue);
            _context.SaveChanges();
        }

        public void DeleteStationQueue(Guid id)
        {
            _context.StationQueues.Remove(_context.StationQueues.Find(id));
            _context.SaveChanges();
        }

        public StationQueue GetStationQueue(Guid id)
        {
            return _context.StationQueues.Find(id);
        }

        public StationQueue GetStationQueue(Guid stationId, Guid itemId)
        {
            return _context.StationQueues.Where(x => x.StationId == stationId && x.ItemId == itemId).FirstOrDefault();
        }

        public ICollection<StationQueue> GetStationQueues()
        {
            return _context.StationQueues.ToList();
        }

        public void UpdateStationQueue(StationQueue stationQueue)
        {
            _context.StationQueues.Update(stationQueue);
            _context.SaveChanges();
        }
    }
}
