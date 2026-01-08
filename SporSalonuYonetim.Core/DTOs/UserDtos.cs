using System;

namespace SporSalonuYonetim.Core.DTOs
{
    public class UserDto
    {
        public Guid Id { get; set; }
        public required string FirstName { get; set; }
        public required string LastName { get; set; }
        public required string Email { get; set; }
        public required string Username { get; set; }
        public required string Role { get; set; }
        public Guid? SubscriptionTypeId { get; set; }
        public Guid? TrainerId { get; set; }
    }

    public class UserCreateDto
    {
        public required string FirstName { get; set; }
        public required string LastName { get; set; }
        public required string Email { get; set; }
        public required string Username { get; set; }
        public required string Password { get; set; }
        public required string Role { get; set; } = "User";
        public Guid? SubscriptionTypeId { get; set; }
    }

    public class UserUpdateDto
    {
        public Guid Id { get; set; }
        public required string FirstName { get; set; }
        public required string LastName { get; set; }
        public required string Email { get; set; }
        public required string Username { get; set; }
        public string? Role { get; set; }
        public Guid? SubscriptionTypeId { get; set; }
        public Guid? TrainerId { get; set; }
    }
}
