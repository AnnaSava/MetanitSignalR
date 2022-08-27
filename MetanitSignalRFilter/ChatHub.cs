using Microsoft.AspNetCore.SignalR;

namespace MetanitSignalRFilter
{
    public class ChatHub : Hub
    {
        public async Task Send(string username, string message)
        {
            await this.Clients.All.SendAsync("Receive", username, message);
        }
    }
}
