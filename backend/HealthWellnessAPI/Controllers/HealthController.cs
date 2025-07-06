using Microsoft.AspNetCore.Mvc;
using HealthWellnessAPI.Models;
using HealthWellnessAPI.Services;

namespace HealthWellnessAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class HealthController : ControllerBase
    {
        private readonly IHealthService _healthService;
        private readonly IMLPredictionService _mlService;

        public HealthController(IHealthService healthService, IMLPredictionService mlService)
        {
            _healthService = healthService;
            _mlService = mlService;
        }

        [HttpGet("metrics/{userId}")]
        public async Task<ActionResult<HealthMetrics>> GetHealthMetrics(string userId)
        {
            var metrics = await _healthService.GetHealthMetricsAsync(userId);
            return Ok(metrics);
        }

        // [HttpPost("metrics")]
        // public async Task<ActionResult> UpdateHealthMetrics([FromBody] 
        // HealthMetricsUpdate update)
        [HttpPut("metrics/{userId}")]
        public async Task<ActionResult<HealthMetrics>> UpdateHealthMetrics(string userId, [FromBody] HealthMetricsUpdate update)
        {
            // await _healthService.UpdateHealthMetricsAsync(update);
            // return Ok();
            var metrics = await _healthService.UpdateHealthMetricsAsync(userId, update);
            return Ok(metrics);
        }

        [HttpGet("insights/{userId}")]
        public async Task<ActionResult<List<HealthInsight>>> GetHealthInsights(string userId)
        {
            var insights = await _healthService.GetHealthInsightsAsync(userId);
            return Ok(insights);
        }

        [HttpGet("predictions/{userId}")]
        public async Task<ActionResult<MLPredictions>> GetMLPredictions(string userId)
        {
            var predictions = await _mlService.GeneratePredictionsAsync(userId);
            return Ok(predictions);
        }

        [HttpPost("wellness-plan/{userId}")]
        public async Task<ActionResult<WellnessPlan>> CreateWellnessPlan(string userId, [FromBody] WellnessPlanRequest request)
        {
            var plan = await _healthService.CreateWellnessPlanAsync(userId, request);
            return Ok(plan);
        }

        [HttpGet("wellness-plan/{userId}")]
        public async Task<ActionResult<WellnessPlan>> GetWellnessPlan(string userId)
        {
            var plan = await _healthService.GetWellnessPlanAsync(userId);
            return Ok(plan);
        }

        [HttpGet("health-score/{userId}")]
        public async Task<ActionResult<HealthScore>> CalculateHealthScore(string userId)
        {
            var score = await _healthService.CalculateHealthScoreAsync(userId);
            return Ok(score);
        }
    }
}
