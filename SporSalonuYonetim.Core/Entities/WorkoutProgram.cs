using System;

namespace SporSalonuYonetim.Core.Entities
{
    public class WorkoutProgram : BaseEntity
    {
        public required string ProgramName { get; set; }
        public required string Details { get; set; }

        public Guid UserId { get; set; }
        public User User { get; set; } = null!;

        public Guid TrainerId { get; set; }
        public Trainer Trainer { get; set; } = null!;
    }
}
