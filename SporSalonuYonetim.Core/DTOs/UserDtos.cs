using System;

namespace SporSalonuYonetim.Core.DTOs
{
    public class UserDto
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Role { get; set; }
        public Guid? SubscriptionTypeId { get; set; }
        public Guid? TrainerId { get; set; }
    }

    public class UserCreateDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public Guid? SubscriptionTypeId { get; set; }
    }

    public class UserUpdateDto
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public Guid? SubscriptionTypeId { get; set; }
        public Guid? TrainerId { get; set; }
    }
}
