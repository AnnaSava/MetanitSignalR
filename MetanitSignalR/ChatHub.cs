using Microsoft.AspNetCore.SignalR;

namespace MetanitSignalR
{
    public class ChatHub : Hub
    {
        public async Task Send(string message, string userName)
        {
            await this.Clients.All.SendAsync("Receive", message, userName, Context.ConnectionId);
        }

        public override async Task OnConnectedAsync()
        {
            var context = Context.GetHttpContext();
            if (context is not null)
            {
                // получаем кук name
                if (context.Request.Cookies.ContainsKey("name"))
                {
                    if (context.Request.Cookies.TryGetValue("name", out var userName))
                    {
                        Console.WriteLine($"name = {userName}");
                    }
                }
                // получаем юзер-агент
                Console.WriteLine($"UserAgent = {context.Request.Headers["User-Agent"]}");
                // получаем ip
                Console.WriteLine($"RemoteIpAddress = {context.Connection?.RemoteIpAddress?.ToString()}");

                await base.OnConnectedAsync();
            }
        }
    }
}
