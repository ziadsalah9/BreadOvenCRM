using Microsoft.AspNetCore.SignalR;

namespace BreadOven.Hubs
{
    public class NotificationHub : Hub
    {


        public async Task SendNotifiaction (string Message)
        {
            await Clients.All.SendAsync ("ReceiveNotification", Message);
        }

    }
}
