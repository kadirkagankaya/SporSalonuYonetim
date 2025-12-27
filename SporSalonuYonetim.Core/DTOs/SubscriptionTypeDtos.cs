namespace SporSalonuYonetim.Core.DTOs
{
    public class SubscriptionTypeDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int DurationMonths { get; set; }
        public decimal Price { get; set; }
    }

    public class SubscriptionTypeCreateDto
    {
        public string Name { get; set; }
        public int DurationMonths { get; set; }
        public decimal Price { get; set; }
    }
}
