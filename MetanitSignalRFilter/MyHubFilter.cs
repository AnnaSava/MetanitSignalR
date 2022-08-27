using Microsoft.AspNetCore.SignalR;

namespace MetanitSignalRFilter
{
    public class MyHubFilter : IHubFilter
    {
        public async ValueTask<object?> InvokeMethodAsync(
            HubInvocationContext invocationContext,
            Func<HubInvocationContext, ValueTask<object?>> next)
        {
            // получаем вызываемый метод хаба
            Console.WriteLine($"Вызов метода {invocationContext.HubMethodName}");
            try
            {
                return await next(invocationContext);   // вызываем следующий фильтр или метод хаба
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Не удалось вызвать метод {invocationContext.HubMethodName}: {ex.Message}");
                throw;
            }
        }
        public Task OnConnectedAsync(HubLifetimeContext context, Func<HubLifetimeContext, Task> next)
        {
            Console.WriteLine("Вызов метода OnConnectedAsync");
            return next(context);
        }

        public Task OnDisconnectedAsync(
            HubLifetimeContext context, Exception? exception, Func<HubLifetimeContext, Exception, Task> next)
        {
            Console.WriteLine("Вызов метода OnDisconnectedAsync");
            return next(context, exception!);
        }
    }
}
