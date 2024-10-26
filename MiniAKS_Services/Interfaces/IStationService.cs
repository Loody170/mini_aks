using MiniAKS_Database.Dtos;
using MiniAKS_Database.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniAKS_Services.Interfaces
{
    public interface IStationService
    {
        public StationDto GetStation(Guid id);
        public ICollection<StationDto> GetStations();
        public ICollection<Item> GetStationItems(Guid id);
    }
}
