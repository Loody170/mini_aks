using MiniAKS_Database.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniAKS_Services.Interfaces
{
    public interface IStationQueueService
    {
        public ICollection<StationQueue> GetStationQueues();
        public StationQueue GetStationQueue(Guid id);
        public void AddOrUpdateStationQueue(Guid stationId, Guid itemId, int quantity);
        public void DeleteStationQueue(Guid id);
    }
}
