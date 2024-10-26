using Microsoft.AspNetCore.Mvc;
using MiniAKS_Services.Interfaces;

namespace MiniAKS.Controllers
{
    [Route("api/[controller]")]
    public class StationController: ControllerBase
    {
        private readonly IStationService _stationService;
        public StationController(IStationService stationService)
        {
            _stationService = stationService;
        }

        [HttpGet("{stationId}")]
        public IActionResult GetStation(Guid stationId)
        {
            var station = _stationService.GetStation(stationId);
            return Ok(station);
        }

        [HttpGet]
        public IActionResult GetStations()
        {
            var stations = _stationService.GetStations();
            return Ok(stations);
        }

        [HttpGet("{stationId}/items")]
        public IActionResult GetStationItems(Guid stationId) { 
            var stationItems = _stationService.GetStationItems(stationId);
            return Ok(stationItems);
        }
    }
}
