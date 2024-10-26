namespace MiniAKS_Database.Models
{
    public class Station
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string DisplayName { get; set; }
        public ICollection<Item> Items { get; set; }
        public ICollection<StationQueue> StationQueues { get; set; }
    }
}
