// ai cursor
using HealthWellnessAPI.Data;
using HealthWellnessAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace HealthWellnessAPI.Services
{
    public class HealthService : IHealthService
    {
        private readonly HealthWellnessContext _context;

        public HealthService(HealthWellnessContext context)
        {
            _context = context;
        }

        public async Task<HealthMetrics> GetHealthMetricsAsync(string userId)
        {
            var metrics = await _context.HealthMetrics
                .FirstOrDefaultAsync(m => m.UserId == userId);

            if (metrics == null)
            {
                // Return default metrics if user doesn't exist
                metrics = new HealthMetrics
                {
                    UserId = userId,
                    Steps = 0,
                    HeartRate = 70,
                    WaterIntake = 0,
                    SleepDuration = TimeSpan.FromHours(7),
                    CaloriesBurned = 0,
                    LastUpdated = DateTime.UtcNow
                };
            }

            return metrics;
        }

        public async Task<HealthMetrics> UpdateHealthMetricsAsync(string userId, HealthMetricsUpdate update)
        {
            var metrics = await _context.HealthMetrics
                .FirstOrDefaultAsync(m => m.UserId == userId);

            if (metrics == null)
            {
                metrics = new HealthMetrics
                {
                    UserId = userId,
                    Steps = update.Steps ?? 0,
                    HeartRate = update.HeartRate ?? 70,
                    WaterIntake = update.WaterIntake ?? 0,
                    SleepDuration = update.SleepDuration ?? TimeSpan.FromHours(7),
                    CaloriesBurned = update.CaloriesBurned ?? 0,
                    LastUpdated = DateTime.UtcNow
                };
                _context.HealthMetrics.Add(metrics);
            }
            else
            {
                if (update.Steps.HasValue) metrics.Steps = update.Steps.Value;
                if (update.HeartRate.HasValue) metrics.HeartRate = update.HeartRate.Value;
                if (update.WaterIntake.HasValue) metrics.WaterIntake = update.WaterIntake.Value;
                if (update.SleepDuration.HasValue) metrics.SleepDuration = update.SleepDuration.Value;
                if (update.CaloriesBurned.HasValue) metrics.CaloriesBurned = update.CaloriesBurned.Value;
                metrics.LastUpdated = DateTime.UtcNow;
            }

            await _context.SaveChangesAsync();
            return metrics;
        }

        public async Task<List<HealthInsight>> GetHealthInsightsAsync(string userId)
        {
            var metrics = await GetHealthMetricsAsync(userId);
            var insights = new List<HealthInsight>();

            // Generate insights based on health metrics
            if (metrics.Steps < 5000)
            {
                insights.Add(new HealthInsight
                {
                    Type = "warning",
                    Title = "Low Activity Level",
                    Description = "Your daily step count is below the recommended 8,000 steps.",
                    Impact = "Medium",
                    Category = "Fitness",
                    Recommendation = "Try to increase your daily steps gradually. Start with a 10-minute walk.",
                    GeneratedAt = DateTime.UtcNow
                });
            }
            else if (metrics.Steps >= 8000)
            {
                insights.Add(new HealthInsight
                {
                    Type = "positive",
                    Title = "Great Activity Level",
                    Description = "You're meeting the recommended daily step goal!",
                    Impact = "High",
                    Category = "Fitness",
                    Recommendation = "Keep up the great work! Consider adding strength training.",
                    GeneratedAt = DateTime.UtcNow
                });
            }

            if (metrics.HeartRate > 100)
            {
                insights.Add(new HealthInsight
                {
                    Type = "warning",
                    Title = "Elevated Heart Rate",
                    Description = "Your heart rate is above normal resting levels.",
                    Impact = "High",
                    Category = "Cardiovascular",
                    Recommendation = "Consider stress management techniques and consult a healthcare provider if persistent.",
                    GeneratedAt = DateTime.UtcNow
                });
            }

            if (metrics.SleepDuration < TimeSpan.FromHours(6))
            {
                insights.Add(new HealthInsight
                {
                    Type = "warning",
                    Title = "Insufficient Sleep",
                    Description = "You're getting less than the recommended 7-9 hours of sleep.",
                    Impact = "High",
                    Category = "Sleep",
                    Recommendation = "Establish a consistent bedtime routine and aim for 7-9 hours of sleep.",
                    GeneratedAt = DateTime.UtcNow
                });
            }

            return insights;
        }

        public async Task<WellnessPlan> GetWellnessPlanAsync(string userId)
        {
            var plan = await _context.WellnessPlans
                .FirstOrDefaultAsync(p => p.UserId == userId);

            if (plan == null)
            {
                // Create a default wellness plan
                plan = await CreateWellnessPlanAsync(userId, new WellnessPlanRequest
                {
                    FocusAreas = new List<string> { "Fitness", "Sleep", "Nutrition" },
                    FitnessLevel = "Beginner",
                    HealthGoals = new List<string> { "Improve overall health", "Increase energy levels" },
                    Preferences = new Dictionary<string, object>()
                });
            }

            return plan;
        }

        public async Task<WellnessPlan> CreateWellnessPlanAsync(string userId, WellnessPlanRequest request)
        {
            var plan = new WellnessPlan
            {
                UserId = userId,
                DailyTasks = GenerateDailyTasks(request),
                WeeklyGoals = GenerateWeeklyGoals(request),
                AIRecommendations = GenerateAIRecommendations(request),
                CreatedAt = DateTime.UtcNow
            };

            _context.WellnessPlans.Add(plan);
            await _context.SaveChangesAsync();

            return plan;
        }

        public async Task<HealthScore> CalculateHealthScoreAsync(string userId)
        {
            var metrics = await GetHealthMetricsAsync(userId);
            var categoryScores = new Dictionary<string, int>();
            var improvementAreas = new List<string>();
            var strengths = new List<string>();

            // Calculate fitness score
            var fitnessScore = CalculateFitnessScore(metrics);
            categoryScores["Fitness"] = fitnessScore;
            if (fitnessScore < 70) improvementAreas.Add("Increase daily physical activity");
            else strengths.Add("Good fitness level");

            // Calculate sleep score
            var sleepScore = CalculateSleepScore(metrics);
            categoryScores["Sleep"] = sleepScore;
            if (sleepScore < 70) improvementAreas.Add("Improve sleep quality and duration");
            else strengths.Add("Healthy sleep patterns");

            // Calculate cardiovascular score
            var cardioScore = CalculateCardiovascularScore(metrics);
            categoryScores["Cardiovascular"] = cardioScore;
            if (cardioScore < 70) improvementAreas.Add("Monitor heart rate and stress levels");
            else strengths.Add("Good cardiovascular health");

            // Calculate overall score
            var overallScore = (fitnessScore + sleepScore + cardioScore) / 3;

            return new HealthScore
            {
                OverallScore = (int)overallScore,
                CategoryScores = categoryScores,
                ImprovementAreas = improvementAreas,
                Strengths = strengths
            };
        }

        private List<WellnessTask> GenerateDailyTasks(WellnessPlanRequest request)
        {
            var tasks = new List<WellnessTask>();

            if (request.FocusAreas.Contains("Fitness"))
            {
                tasks.Add(new WellnessTask
                {
                    Task = "Take a 30-minute walk",
                    Category = "Fitness",
                    Priority = "High",
                    IsCompleted = false
                });
            }

            if (request.FocusAreas.Contains("Sleep"))
            {
                tasks.Add(new WellnessTask
                {
                    Task = "Practice 10 minutes of meditation before bed",
                    Category = "Sleep",
                    Priority = "Medium",
                    IsCompleted = false
                });
            }

            if (request.FocusAreas.Contains("Nutrition"))
            {
                tasks.Add(new WellnessTask
                {
                    Task = "Drink 8 glasses of water",
                    Category = "Nutrition",
                    Priority = "High",
                    IsCompleted = false
                });
            }

            return tasks;
        }

        private List<WellnessGoal> GenerateWeeklyGoals(WellnessPlanRequest request)
        {
            var goals = new List<WellnessGoal>();

            if (request.FocusAreas.Contains("Fitness"))
            {
                goals.Add(new WellnessGoal
                {
                    Goal = "Complete 5 workouts this week",
                    Progress = 0,
                    Current = 0,
                    Target = 5
                });
            }

            if (request.FocusAreas.Contains("Sleep"))
            {
                goals.Add(new WellnessGoal
                {
                    Goal = "Get 7+ hours of sleep for 5 nights",
                    Progress = 0,
                    Current = 0,
                    Target = 5
                });
            }

            return goals;
        }

        private List<string> GenerateAIRecommendations(WellnessPlanRequest request)
        {
            var recommendations = new List<string>();

            if (request.FitnessLevel == "Beginner")
            {
                recommendations.Add("Start with low-impact exercises like walking or swimming");
                recommendations.Add("Gradually increase intensity over 4-6 weeks");
            }

            recommendations.Add("Track your progress daily to stay motivated");
            recommendations.Add("Set realistic, achievable goals");

            return recommendations;
        }

        private int CalculateFitnessScore(HealthMetrics metrics)
        {
            var score = 50; // Base score

            // Steps contribution
            if (metrics.Steps >= 10000) score += 30;
            else if (metrics.Steps >= 8000) score += 25;
            else if (metrics.Steps >= 6000) score += 20;
            else if (metrics.Steps >= 4000) score += 10;

            // Calories burned contribution
            if (metrics.CaloriesBurned >= 300) score += 20;
            else if (metrics.CaloriesBurned >= 200) score += 15;
            else if (metrics.CaloriesBurned >= 100) score += 10;

            return Math.Min(100, score);
        }

        private int CalculateSleepScore(HealthMetrics metrics)
        {
            var score = 50; // Base score

            // Sleep duration contribution
            if (metrics.SleepDuration >= TimeSpan.FromHours(8)) score += 30;
            else if (metrics.SleepDuration >= TimeSpan.FromHours(7)) score += 25;
            else if (metrics.SleepDuration >= TimeSpan.FromHours(6)) score += 15;
            else if (metrics.SleepDuration >= TimeSpan.FromHours(5)) score += 5;

            // Sleep quality indicators (simplified)
            if (metrics.HeartRate >= 60 && metrics.HeartRate <= 80) score += 20;

            return Math.Min(100, score);
        }

        private int CalculateCardiovascularScore(HealthMetrics metrics)
        {
            var score = 50; // Base score

            // Heart rate contribution
            if (metrics.HeartRate >= 60 && metrics.HeartRate <= 80) score += 30;
            else if (metrics.HeartRate >= 50 && metrics.HeartRate <= 90) score += 20;
            else if (metrics.HeartRate >= 40 && metrics.HeartRate <= 100) score += 10;

            // Activity level contribution
            if (metrics.Steps >= 8000) score += 20;
            else if (metrics.Steps >= 6000) score += 15;
            else if (metrics.Steps >= 4000) score += 10;

            return Math.Min(100, score);
        }
    }
} 