using System;

namespace SporSalonuYonetim.Core.DTOs
{
    public class WorkoutProgramDto
    {
        public Guid Id { get; set; }
        public required string ProgramName { get; set; }
        public required string Details { get; set; }
        public Guid UserId { get; set; }
        public Guid TrainerId { get; set; }
    }

    public class WorkoutProgramCreateDto
    {
        public required string ProgramName { get; set; }
        public required string Details { get; set; }
        public Guid UserId { get; set; }
        public Guid TrainerId { get; set; }
    }
}
