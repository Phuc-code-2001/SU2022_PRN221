using Microsoft.AspNetCore.SignalR;
using ShinyTeeth.Models;
using System;
using System.Threading.Tasks;

namespace ShinyTeeth.Hubs
{
    public class SignalRServerHub : Hub
    {
        public static int numberOfConnection = 0;

        public override async Task OnConnectedAsync()
        {
            numberOfConnection++;
            await base.OnConnectedAsync();
            System.Console.WriteLine($"{Context.User.Identity.Name} ===> Number Of Connection: {numberOfConnection}");
        }

        public override async Task OnDisconnectedAsync(Exception exception)
        {
            numberOfConnection--;
            await base.OnDisconnectedAsync(exception);
            System.Console.WriteLine($"{Context.User.Identity.Name} leave ===> Number Of Connection: {numberOfConnection}");
        }

        public static async Task SendNotification(IHubContext<SignalRServerHub> hubContext, Notification notification)
        {
            await hubContext.Clients.User(notification.ReceiverId).SendAsync("receiveNotification", notification);
        }

    }
}
