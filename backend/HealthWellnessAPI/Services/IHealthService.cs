// ai cursor
using HealthWellnessAPI.Models;

namespace HealthWellnessAPI.Services
{
    public interface IHealthService
    {
        Task<HealthMetrics> GetHealthMetricsAsync(string userId);
        Task<HealthMetrics> UpdateHealthMetricsAsync(string userId, HealthMetricsUpdate update);
        Task<List<HealthInsight>> GetHealthInsightsAsync(string userId);
        Task<WellnessPlan> GetWellnessPlanAsync(string userId);
        Task<WellnessPlan> CreateWellnessPlanAsync(string userId, WellnessPlanRequest request);
        Task<HealthScore> CalculateHealthScoreAsync(string userId);
    }
} 