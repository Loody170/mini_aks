namespace MiniAKS_Database.Models
{
    public class Item
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public DateTime CreatedDate { get; set; }
        public int HoldingTimeAfterCooking { get; set; }
        public int DrainageTime {  get; set; }
        public int PreparationTime { get; set; }
        public ICollection<ProductItem> ProductItems { get; set; }
        public Guid StationId { get; set; }
        public Station Station { get; set; }

    }
}
