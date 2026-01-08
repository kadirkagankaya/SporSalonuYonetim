using System;

namespace SporSalonuYonetim.Core.DTOs
{
    public class TrainerDto
    {
        public Guid Id { get; set; }
        public required string FullName { get; set; }
        public required string Specialization { get; set; }
    }

    public class TrainerCreateDto
    {
        public required string FullName { get; set; }
        public required string Specialization { get; set; }
    }

    public class TrainerUpdateDto
    {
        public Guid Id { get; set; }
        public required string FullName { get; set; }
        public required string Specialization { get; set; }
    }
}
