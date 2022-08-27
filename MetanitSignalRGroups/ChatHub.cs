using Microsoft.AspNetCore.SignalR;

namespace MetanitSignalRGroups
{
    public class ChatHub : Hub
    {
        public async Task Enter(string username, string groupName)
        {
            await Groups.AddToGroupAsync(Context.ConnectionId, groupName);
            await Clients.All.SendAsync("Notify", $"{username} вошел в чат в группу {groupName}");
        }
        public async Task Send(string message, string userName, string groupName)
        {
            await Clients.Group(groupName).SendAsync("Receive", message, userName);
        }
    }
}
