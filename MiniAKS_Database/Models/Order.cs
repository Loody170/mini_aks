namespace MiniAKS_Database.Models
{
    public class Order
    {
        public Guid Id { get; set; }
        public string OrderNumber { get; set; }
        public DateTime PlacedOn { get; set; }
        public DateTime PrintedOn { get; set; }
        public DateTime? CompletedOn { get; set; }
        public ICollection<OrderProduct> OrderProducts { get; set; }
    }
}
