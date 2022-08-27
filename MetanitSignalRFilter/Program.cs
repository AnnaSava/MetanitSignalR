using MetanitSignalRFilter;
using Microsoft.AspNetCore.SignalR;

var builder = WebApplication.CreateBuilder(args);

// регистрация фильтра (Transient)
builder.Services.AddSignalR(options => options.AddFilter<MyHubFilter>()) // глобальная регистрация фильтра
    .AddHubOptions<ChatHub>(options => options.AddFilter<YukhHubFilter>()); // локальная регистрация фильтра

// регистрация фильтра (Singleton)
//builder.Services.AddSignalR(options => options.AddFilter(new MyHubFilter())) // глобальная регистрация фильтра
//    .AddHubOptions<ChatHub>(options => options.AddFilter(new YukhHubFilter()); // локальная регистрация фильтра

var app = builder.Build();

app.UseDefaultFiles();
app.UseStaticFiles();

app.MapHub<ChatHub>("/chat");
app.Run();
