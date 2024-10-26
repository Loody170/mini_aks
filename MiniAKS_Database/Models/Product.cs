namespace MiniAKS_Database.Models
{
    public class Product
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public DateTime CreatedDate { get; set; }
        public ICollection<ProductItem> ProductItems { get; set; }
        public ICollection<OrderProduct> OrderProducts { get; set; }

    }
}
