using System;

namespace SporSalonuYonetim.Core.Entities
{
    public class WorkoutProgram : BaseEntity
    {
        public string ProgramName { get; set; }
        public string Details { get; set; }

        public Guid UserId { get; set; }
        public User User { get; set; }

        public Guid TrainerId { get; set; }
        public Trainer Trainer { get; set; }
    }
}
