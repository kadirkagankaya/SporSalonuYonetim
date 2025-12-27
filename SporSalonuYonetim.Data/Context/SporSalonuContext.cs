using Microsoft.EntityFrameworkCore;
using MongoDB.EntityFrameworkCore.Extensions;
using SporSalonuYonetim.Core.Entities;

namespace SporSalonuYonetim.Data.Context
{
    public class SporSalonuContext : DbContext
    {
        public SporSalonuContext(DbContextOptions<SporSalonuContext> options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Trainer> Trainers { get; set; }
        public DbSet<SubscriptionType> SubscriptionTypes { get; set; }
        public DbSet<WorkoutProgram> WorkoutPrograms { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            
            modelBuilder.Entity<User>().ToCollection("users");
            modelBuilder.Entity<Trainer>().ToCollection("trainers");
            modelBuilder.Entity<SubscriptionType>().ToCollection("subscription_types");
            modelBuilder.Entity<WorkoutProgram>().ToCollection("workout_programs");
        }
    }
}
