using MiniAKS_Database.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniAKS_Database.Repositories.Interfaces
{
    public interface IStationRepository
    {
        public Station GetStation(Guid id);
        public ICollection<Station> GetStations();
        public ICollection<Item> GetStationItems(Guid id);
    }
}
