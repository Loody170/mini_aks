using Microsoft.AspNetCore.Mvc;
using MiniAKS_Services.Interfaces;

namespace MiniAKS.Controllers
{
    [Route("api/[controller]")]
    public class CustomizationController : ControllerBase
    {
        private readonly ICustomizationService _customizationService;

        public CustomizationController(ICustomizationService customizationService)
        {
            _customizationService = customizationService;
            
        }


        [HttpGet("{customizationId}")]
        public IActionResult GetCustomization(Guid customizationId)
        {
            var customization = _customizationService.GetCustomization(customizationId);
            return Ok(customization);

        }

        [HttpGet]
        public IActionResult GetCustomizations()
        {
            var customizations = _customizationService.GetCustomizations();
            return Ok(customizations);
        }

        [HttpGet("{orderId}/{productId}")]
        public IActionResult getCustomizationForAnOrderProduct(Guid orderId, Guid productId)
        {
            var customizations = _customizationService.GetCustomizationForAProductInAnOrder(orderId, productId);
            return Ok(customizations);

        }

    }
}
