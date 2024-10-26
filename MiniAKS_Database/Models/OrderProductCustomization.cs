using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MiniAKS_Database.Models
{
    public class OrderProductCustomization
    {
        [Key, Column(Order = 0)]
        public Guid OrderId { get; set; }

        [Key, Column(Order = 1)]
        public Guid ProductId { get; set; }

        public OrderProduct OrderProduct { get; set; }

        [Key, Column(Order = 2)]
        public Guid CustomizationId { get; set; }

        public Customization Customization { get; set; }
    }
}
