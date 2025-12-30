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
            
            modelBuilder.Entity<User>().ToCollection("users").HasQueryFilter(u => !u.IsDeleted);
            modelBuilder.Entity<Trainer>().ToCollection("trainers").HasQueryFilter(t => !t.IsDeleted);
            modelBuilder.Entity<SubscriptionType>().ToCollection("subscription_types").HasQueryFilter(s => !s.IsDeleted);
            modelBuilder.Entity<WorkoutProgram>().ToCollection("workout_programs").HasQueryFilter(w => !w.IsDeleted);
        }

        public override int SaveChanges()
        {
            ApplyTimestamps();
            return base.SaveChanges();
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            ApplyTimestamps();
            return base.SaveChangesAsync(cancellationToken);
        }

        private void ApplyTimestamps()
        {
            var entries = ChangeTracker.Entries<BaseEntity>();

            foreach (var entry in entries)
            {
                if (entry.State == EntityState.Added)
                {
                    entry.Entity.CreatedAt = DateTime.UtcNow;
                }
                else if (entry.State == EntityState.Modified)
                {
                    entry.Entity.UpdatedAt = DateTime.UtcNow;
                }
            }
        }
    }
}
