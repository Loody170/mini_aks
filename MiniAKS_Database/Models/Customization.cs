using Microsoft.EntityFrameworkCore;

namespace MiniAKS_Database.Models
{
    public class Customization
    {
        public Guid Id { get; set; }
        public string Value { get; set; }
        public int Code { get; set; }
        public DateTime CreatedDate { get; set; }
        //public Guid OrderProductId { get; set; } 
    }
}
