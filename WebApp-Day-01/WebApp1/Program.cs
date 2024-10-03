var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/", () => "DOTNET c# training!");

app.Run();
