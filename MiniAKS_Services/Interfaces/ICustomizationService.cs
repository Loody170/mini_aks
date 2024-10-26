using MiniAKS_Database.Dtos;
using MiniAKS_Database.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniAKS_Services.Interfaces
{
    public interface ICustomizationService
    {
        public CustomizationDto GetCustomization(Guid id);
        public CustomizationDto GetCustomazationByCode(string code);
        public ICollection<CustomizationDto> GetCustomizations();
        public ICollection<CustomizationDto> GetCustomizationForAProductInAnOrder(Guid orderId, Guid productId);

    }
}
