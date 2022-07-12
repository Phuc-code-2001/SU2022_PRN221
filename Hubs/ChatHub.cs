using Microsoft.AspNetCore.SignalR;
using System;
using System.Threading.Tasks;

namespace ShinyTeeth.Hubs
{
    public class ChatHub : Hub
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

        // For Debuging
        public async Task SendToCaller(string message)
        {
            await Clients.Caller.SendAsync("receiveTestMessage", Context.ConnectionId, message);
        }
        // For Debuging
        public async Task SendToAllUser(string message)
        {
            await Clients.All.SendAsync("receiveTestMessage", Context.ConnectionId, message);
        }




    }
}
