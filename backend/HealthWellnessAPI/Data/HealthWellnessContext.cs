using Microsoft.EntityFrameworkCore;
using HealthWellnessAPI.Models;

namespace HealthWellnessAPI.Data
{
    public class HealthWellnessContext : DbContext
    {
        public HealthWellnessContext(DbContextOptions<HealthWellnessContext> options)
            : base(options)
        {
        }

        public DbSet<HealthMetrics> HealthMetrics { get; set; }
        public DbSet<HealthInsight> HealthInsights { get; set; }
        public DbSet<WellnessPlan> WellnessPlans { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configure HealthMetrics
            modelBuilder.Entity<HealthMetrics>(entity =>
            {
                entity.HasKey(e => e.UserId);
                entity.Property(e => e.Steps).IsRequired();
                entity.Property(e => e.HeartRate).IsRequired();
                entity.Property(e => e.WaterIntake).IsRequired();
                entity.Property(e => e.SleepDuration).IsRequired();
                entity.Property(e => e.CaloriesBurned).IsRequired();
                entity.Property(e => e.LastUpdated).IsRequired();
            });

            // Configure HealthInsight
            modelBuilder.Entity<HealthInsight>(entity =>
            {
                entity.HasKey(e => new { e.Type, e.GeneratedAt });
                entity.Property(e => e.Type).IsRequired();
                entity.Property(e => e.Title).IsRequired();
                entity.Property(e => e.Description).IsRequired();
                entity.Property(e => e.Impact).IsRequired();
                entity.Property(e => e.Category).IsRequired();
                entity.Property(e => e.Recommendation).IsRequired();
                entity.Property(e => e.GeneratedAt).IsRequired();
            });

            // Configure WellnessPlan
            modelBuilder.Entity<WellnessPlan>(entity =>
            {
                entity.HasKey(e => e.UserId);
                entity.Property(e => e.UserId).IsRequired();
                entity.Property(e => e.CreatedAt).IsRequired();
                
                // Configure complex properties as JSON
                entity.Property(e => e.DailyTasks)
                    .HasConversion(
                        v => System.Text.Json.JsonSerializer.Serialize(v, (System.Text.Json.JsonSerializerOptions?)null),
                        v => System.Text.Json.JsonSerializer.Deserialize<List<WellnessTask>>(v, (System.Text.Json.JsonSerializerOptions?)null) ?? new List<WellnessTask>());
                
                entity.Property(e => e.WeeklyGoals)
                    .HasConversion(
                        v => System.Text.Json.JsonSerializer.Serialize(v, (System.Text.Json.JsonSerializerOptions?)null),
                        v => System.Text.Json.JsonSerializer.Deserialize<List<WellnessGoal>>(v, (System.Text.Json.JsonSerializerOptions?)null) ?? new List<WellnessGoal>());
                
                entity.Property(e => e.AIRecommendations)
                    .HasConversion(
                        v => System.Text.Json.JsonSerializer.Serialize(v, (System.Text.Json.JsonSerializerOptions?)null),
                        v => System.Text.Json.JsonSerializer.Deserialize<List<string>>(v, (System.Text.Json.JsonSerializerOptions?)null) ?? new List<string>());
            });
        }
    }
} 