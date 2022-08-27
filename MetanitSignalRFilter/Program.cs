using MetanitSignalRFilter;
using Microsoft.AspNetCore.SignalR;

var builder = WebApplication.CreateBuilder(args);

// ����������� ������� (Transient)
builder.Services.AddSignalR(options => options.AddFilter<MyHubFilter>()) // ���������� ����������� �������
    .AddHubOptions<ChatHub>(options => options.AddFilter<YukhHubFilter>()); // ��������� ����������� �������

// ����������� ������� (Singleton)
//builder.Services.AddSignalR(options => options.AddFilter(new MyHubFilter())) // ���������� ����������� �������
//    .AddHubOptions<ChatHub>(options => options.AddFilter(new YukhHubFilter()); // ��������� ����������� �������

var app = builder.Build();

app.UseDefaultFiles();
app.UseStaticFiles();

app.MapHub<ChatHub>("/chat");
app.Run();
