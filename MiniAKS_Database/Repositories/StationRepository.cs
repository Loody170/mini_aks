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
    public class StationRepository : IStationRepository
    {
        private readonly MiniAKSDbContext _context;
        public StationRepository(MiniAKSDbContext context)
        {
            _context = context;
        }

        public Station GetStation(Guid id)
        {
            return _context.Stations.Find(id);
        }

        public ICollection<Item> GetStationItems(Guid id)
        {
            return _context.Items.Where(i => i.StationId == id).ToList();
        }

        public ICollection<Station> GetStations()
        {
            return _context.Stations.ToList();
        }
    }
}
