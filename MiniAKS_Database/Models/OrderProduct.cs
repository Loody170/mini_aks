namespace MiniAKS_Database.Models
{
    public class OrderProduct
    {
        public Guid OrderId { get; set; }
        public Order Order { get; set; }
        public Guid ProductId { get; set; }
        public Product Product { get; set; }
        public int Quantity { get; set; }
        public ICollection<OrderProductCustomization> OrderProductCustomizations { get; set; } = new List<OrderProductCustomization>();
    }
}
