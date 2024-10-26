namespace MiniAKS_Database.Models
{
    public class ProductItem
    {
        public Guid ProductId { get; set; }
        public Product Product { get; set; }
        public Guid ItemId { get; set; }
        public Item Item { get; set; }
        public int Quantity { get; set; }
    }
}
