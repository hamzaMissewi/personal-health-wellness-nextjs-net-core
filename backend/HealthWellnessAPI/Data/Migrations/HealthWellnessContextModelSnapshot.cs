using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using HealthWellnessAPI.Data;

#nullable disable

namespace HealthWellnessAPI.Data.Migrations
{
    [DbContext(typeof(HealthWellnessContext))]
    partial class HealthWellnessContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("HealthWellnessAPI.Models.HealthInsight", b =>
                {
                    b.Property<string>("Type")
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("GeneratedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Impact")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Category")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Recommendation")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Type", "GeneratedAt");

                    b.ToTable("HealthInsights");
                });

            modelBuilder.Entity("HealthWellnessAPI.Models.HealthMetrics", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("Steps")
                        .HasColumnType("int");

                    b.Property<int>("HeartRate")
                        .HasColumnType("int");

                    b.Property<double>("WaterIntake")
                        .HasColumnType("float");

                    b.Property<TimeSpan>("SleepDuration")
                        .HasColumnType("time");

                    b.Property<int>("CaloriesBurned")
                        .HasColumnType("int");

                    b.Property<DateTime>("LastUpdated")
                        .HasColumnType("datetime2");

                    b.HasKey("UserId");

                    b.ToTable("HealthMetrics");
                });

            modelBuilder.Entity("HealthWellnessAPI.Models.WellnessPlan", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("DailyTasks")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("WeeklyGoals")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("AIRecommendations")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.HasKey("UserId");

                    b.ToTable("WellnessPlans");
                });
#pragma warning restore 612, 618
        }
    }
} 