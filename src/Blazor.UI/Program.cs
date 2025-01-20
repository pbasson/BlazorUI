using Blazor.UI.Helpers;

var builder = WebApplication.CreateBuilder(args);
builder.Services.RegisterService();

var app = builder.Build();
app.RegisterApplication();
app.Run();

