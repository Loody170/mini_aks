using AutoMapper;
using MiniAKS_Database.Dtos;
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
    public class StationService : IStationService
    {
        private readonly IStationRepository _stationRepository;
        private readonly IMapper _mapper;
        public StationService(IStationRepository stationRepository, IMapper mapper)
        {
            _stationRepository = stationRepository;
            _mapper = mapper;  
        }
        public StationDto GetStation(Guid id)
        {
            return _mapper.Map<StationDto>(_stationRepository.GetStation(id));
        }

        public ICollection<Item> GetStationItems(Guid id)
        {
            return _stationRepository.GetStationItems(id);
        }

        public ICollection<StationDto> GetStations()
        {
            return _mapper.Map<ICollection<StationDto>>(_stationRepository.GetStations());
        }
    }
}
