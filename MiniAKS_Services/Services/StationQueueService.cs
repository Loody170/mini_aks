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
    public class StationQueueService : IStationQueueService
    {
        private readonly IStationQueueRepository _stationQueueRepository;
        public StationQueueService(IStationQueueRepository stationQueueRepository)
        {
            _stationQueueRepository = stationQueueRepository;
        }
        public void AddOrUpdateStationQueue(Guid stationId, Guid itemId, int quantity)
        {
          StationQueue stationQueue = _stationQueueRepository.GetStationQueue(stationId, itemId);
            if (stationQueue == null)
            {
                stationQueue = new StationQueue
                {
                    StationId = stationId,
                    ItemId = itemId,
                    Quantity = quantity
                };
                _stationQueueRepository.AddStationQueue(stationQueue);
            }
            else
            {
                stationQueue.Quantity += quantity;
                _stationQueueRepository.UpdateStationQueue(stationQueue);
            }
        }

        public void DeleteStationQueue(Guid id)
        {
            _stationQueueRepository.DeleteStationQueue(id);
        }

        public StationQueue GetStationQueue(Guid id)
        {
            return _stationQueueRepository.GetStationQueue(id);
        }

        public ICollection<StationQueue> GetStationQueues()
        {
            return _stationQueueRepository.GetStationQueues();
        }
    }
}
