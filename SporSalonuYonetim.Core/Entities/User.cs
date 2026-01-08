using System;
using System.Collections.Generic;

namespace SporSalonuYonetim.Core.Entities
{
    public class User : BaseEntity
    {
        public required string FirstName { get; set; }
        public required string LastName { get; set; }
        public required string Email { get; set; }
        public required string Username { get; set; }
        public string? PasswordHash { get; set; }
        public string Role { get; set; } = "User";
       
        public Guid? SubscriptionTypeId { get; set; }
        public SubscriptionType? SubscriptionType { get; set; }
        public Guid? TrainerId { get; set; }
        public Trainer? Trainer { get; set; }

        public ICollection<WorkoutProgram> WorkoutPrograms { get; set; } = new List<WorkoutProgram>();
    }
}
