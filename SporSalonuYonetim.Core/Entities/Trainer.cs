using System.Collections.Generic;

namespace SporSalonuYonetim.Core.Entities
{
    public class Trainer : BaseEntity
    {
        public required string FullName { get; set; }
        public required string Specialization { get; set; }

        public ICollection<User> Users { get; set; } = new List<User>();

        public ICollection<WorkoutProgram> WorkoutPrograms { get; set; } = new List<WorkoutProgram>();
    }
}
