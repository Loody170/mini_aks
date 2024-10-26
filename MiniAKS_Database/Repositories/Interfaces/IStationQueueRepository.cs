using MiniAKS_Database.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniAKS_Database.Repositories.Interfaces
{
    public interface IStationQueueRepository
    {
        public ICollection<StationQueue> GetStationQueues();
        public StationQueue GetStationQueue(Guid id);
        public StationQueue GetStationQueue(Guid stationId, Guid itemId);
        public void AddStationQueue(StationQueue stationQueue);
        public void UpdateStationQueue(StationQueue stationQueue);
        public void DeleteStationQueue(Guid id);

    }
}
