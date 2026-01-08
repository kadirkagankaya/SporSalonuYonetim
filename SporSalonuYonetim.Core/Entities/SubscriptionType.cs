using System.Collections.Generic;

namespace SporSalonuYonetim.Core.Entities
{
    public class SubscriptionType : BaseEntity
    {
        public required string Name { get; set; }
        public int DurationMonths { get; set; }
        public decimal Price { get; set; }

        public ICollection<User> Users { get; set; } = new List<User>();
    }
}
