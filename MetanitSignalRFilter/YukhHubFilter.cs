using Microsoft.AspNetCore.SignalR;

namespace MetanitSignalRFilter
{
    public class YukhHubFilter : IHubFilter
    {
        public async ValueTask<object?> InvokeMethodAsync(
            HubInvocationContext invocationContext,
            Func<HubInvocationContext, ValueTask<object?>> next)
        {
            // получаем второй параметр метода хаба в переменную message
            if (invocationContext.HubMethodArguments.Count == 2 &&
                invocationContext.HubMethodArguments[1] is string message)
            {
                // заменяем некоторые слова
                message = message.Replace("йух", "***");
                var arguments = invocationContext.HubMethodArguments.ToArray();
                arguments[1] = message;
                // пересоздаем объект HubInvocationContext
                invocationContext = new HubInvocationContext(invocationContext.Context,
                    invocationContext.ServiceProvider,
                    invocationContext.Hub,
                    invocationContext.HubMethod,
                    arguments);
            }
            // передаем этот объект в вызов последующих фильтров или метода хаба
            return await next(invocationContext);
        }
    }
}
