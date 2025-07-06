using Microsoft.AspNetCore.SignalR;

namespace HealthWellnessAPI.Hubs
{
    public class HealthHub : Hub
    {
        public async Task JoinUserGroup(string userId)
        {
            await Groups.AddToGroupAsync(Context.ConnectionId, $"user-{userId}");
        }

        public async Task LeaveUserGroup(string userId)
        {
            await Groups.RemoveFromGroupAsync(Context.ConnectionId, $"user-{userId}");
        }

        public async Task SendHealthUpdate(string userId, object healthData)
        {
            await Clients.Group($"user-{userId}").SendAsync("ReceiveHealthUpdate", healthData);
        }

        public async Task SendNotification(string userId, string message, string type)
        {
            await Clients.Group($"user-{userId}").SendAsync("ReceiveNotification", message, type);
        }

        public async Task SendHealthAlert(string userId, string alertType, string message)
        {
            await Clients.Group($"user-{userId}").SendAsync("ReceiveHealthAlert", alertType, message);
        }
    }
} 