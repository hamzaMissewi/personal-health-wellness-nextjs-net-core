namespace HealthWellnessAPI.Services
{
    public interface INotificationService
    {
        Task SendNotificationAsync(string userId, string message, string type);
        Task SendHealthAlertAsync(string userId, string alertType, string message);
    }
} 