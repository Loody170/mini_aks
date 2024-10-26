using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MiniAKS_Services.Interfaces;

namespace MiniAKS.Controllers
{
    [Route("api/[controller]")]

    public class SalesChannelController : ControllerBase
    {
        private readonly ISalesChannelService _salesChannelService;

        public SalesChannelController(ISalesChannelService salesChannelService)
        {
            _salesChannelService = salesChannelService;
        }

        [HttpGet("{salesChannelId}")]

        public IActionResult GetSalesChannel(Guid salesChannelId)
        {
            var salesChannel = _salesChannelService.GetSalesChannel(salesChannelId);
            return Ok(salesChannel);
        }

        [HttpGet]
        public IActionResult GetSalesChannels()
        {
            var salesChannels = _salesChannelService.GetSalesChannels();
            return Ok(salesChannels);
        }

        [HttpGet("status/{salesChannelId}")]
        public IActionResult GetSalesChannelStatus(Guid salesChannelId)
        {
            return Ok(_salesChannelService.isSalesChannelActive(salesChannelId));
        }
    }
}
