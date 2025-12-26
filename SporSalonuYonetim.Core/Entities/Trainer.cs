using System.Collections.Generic;

namespace SporSalonuYonetim.Core.Entities
{
    public class Trainer : BaseEntity
    {
        public string FullName { get; set; }
        public string Specialization { get; set; }

        public ICollection<User> Users { get; set; }

        public ICollection<WorkoutProgram> WorkoutPrograms { get; set; }
    }
}
