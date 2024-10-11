using Microsoft.EntityFrameworkCore;
using WebApp_MInimal_Api.Model;


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<StudentDb>(opt =>

{ opt.UseInMemoryDatabase("StudentsList");
  opt.EnableDetailedErrors();
}

);

//builder.Services.AddDatabaseDeveloperPageExceptionFilter();

var app = builder.Build();

app.MapGet("/api", () => "Hello Api Test!");

app.Run();
