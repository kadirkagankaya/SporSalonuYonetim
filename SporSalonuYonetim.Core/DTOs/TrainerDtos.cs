using System;

namespace SporSalonuYonetim.Core.DTOs
{
    public class TrainerDto
    {
        public Guid Id { get; set; }
        public string FullName { get; set; }
        public string Specialization { get; set; }
    }

    public class TrainerCreateDto
    {
        public string FullName { get; set; }
        public string Specialization { get; set; }
    }

    public class TrainerUpdateDto
    {
        public Guid Id { get; set; }
        public string FullName { get; set; }
        public string Specialization { get; set; }
    }
}
