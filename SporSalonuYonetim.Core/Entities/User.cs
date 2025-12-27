using System;
using System.Collections.Generic;

namespace SporSalonuYonetim.Core.Entities
{
    public class User : BaseEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string? PasswordHash { get; set; }
        public string Role { get; set; } = "User";
       
        public Guid? SubscriptionTypeId { get; set; }
        public SubscriptionType SubscriptionType { get; set; }
        public Guid? TrainerId { get; set; }
        public Trainer Trainer { get; set; }

        public ICollection<WorkoutProgram> WorkoutPrograms { get; set; }
    }
}
