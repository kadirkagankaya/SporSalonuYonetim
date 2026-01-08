namespace SporSalonuYonetim.Core.DTOs
{
    public class SubscriptionTypeDto
    {
        public Guid Id { get; set; }
        public required string Name { get; set; }
        public int DurationMonths { get; set; }
        public decimal Price { get; set; }
    }

    public class SubscriptionTypeCreateDto
    {
        public required string Name { get; set; }
        public int DurationMonths { get; set; }
        public decimal Price { get; set; }
    }
}
