namespace HealthWellnessAPI.Models
{
    public class HealthMetrics
    {
        public string UserId { get; set; } = string.Empty;
        public int Steps { get; set; }
        public int HeartRate { get; set; }
        public double WaterIntake { get; set; }
        public TimeSpan SleepDuration { get; set; }
        public int CaloriesBurned { get; set; }
        public DateTime LastUpdated { get; set; }
    }

    public class HealthMetricsUpdate
    {
        public string UserId { get; set; } = string.Empty;
        public int? Steps { get; set; }
        public int? HeartRate { get; set; }
        public double? WaterIntake { get; set; }
        public TimeSpan? SleepDuration { get; set; }
        public int? CaloriesBurned { get; set; }
    }

    public class HealthInsight
    {
        public string Type { get; set; } = string.Empty; // positive, warning, neutral
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string Impact { get; set; } = string.Empty; // High, Medium, Low
        public string Category { get; set; } = string.Empty;
        public string Recommendation { get; set; } = string.Empty;
        public DateTime GeneratedAt { get; set; }
    }

    public class MLPredictions
    {
        public OptimalWorkoutTime OptimalWorkout { get; set; } = new();
        public SleepQualityForecast SleepForecast { get; set; } = new();
        public HealthRiskAssessment RiskAssessment { get; set; } = new();
    }

    public class OptimalWorkoutTime
    {
        public TimeSpan RecommendedTime { get; set; }
        public string Reasoning { get; set; } = string.Empty;
        public int ConfidenceLevel { get; set; }
    }

    public class SleepQualityForecast
    {
        public double PredictedQuality { get; set; }
        public string Factors { get; set; } = string.Empty;
        public int ConfidenceLevel { get; set; }
    }

    public class HealthRiskAssessment
    {
        public string RiskLevel { get; set; } = string.Empty;
        public List<string> RiskFactors { get; set; } = new();
        public List<string> Recommendations { get; set; } = new();
        public int ConfidenceLevel { get; set; }
    }

    public class WellnessPlan
    {
        public string UserId { get; set; } = string.Empty;
        public List<WellnessTask> DailyTasks { get; set; } = new();
        public List<WellnessGoal> WeeklyGoals { get; set; } = new();
        public List<string> AIRecommendations { get; set; } = new();
        public DateTime CreatedAt { get; set; }
    }

    public class WellnessTask
    {
        public string Task { get; set; } = string.Empty;
        public string Category { get; set; } = string.Empty;
        public string Priority { get; set; } = string.Empty;
        public bool IsCompleted { get; set; }
    }

    public class WellnessGoal
    {
        public string Goal { get; set; } = string.Empty;
        public int Progress { get; set; }
        public int Current { get; set; }
        public int Target { get; set; }
    }

    public class WellnessPlanRequest
    {
        public List<string> FocusAreas { get; set; } = new();
        public string FitnessLevel { get; set; } = string.Empty;
        public List<string> HealthGoals { get; set; } = new();
        public Dictionary<string, object> Preferences { get; set; } = new();
    }

    public class HealthScore
    {
        public int OverallScore { get; set; }
        public Dictionary<string, int> CategoryScores { get; set; } = new();
        public List<string> ImprovementAreas { get; set; } = new();
        public List<string> Strengths { get; set; } = new();
    }
}
