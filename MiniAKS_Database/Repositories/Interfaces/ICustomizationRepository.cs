using MiniAKS_Database.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniAKS_Database.Repositories.Interfaces
{
    public interface ICustomizationRepository
    {
        public Customization GetCustomization(Guid id);
        public Customization GetCustomazationByCode(int code);
        public ICollection<Customization> GetCustomizations();
        public ICollection<Customization> GetCustomizationForAProductInAnOrder(Guid orderId, Guid productId);
    }
}
