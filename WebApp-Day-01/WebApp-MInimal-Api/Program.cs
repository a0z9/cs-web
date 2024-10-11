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

app.MapGet("/students", async (StudentDb db) =>
await db.Students.ToListAsync()
 );

app.MapGet("/students/{id}", async (int id, StudentDb db) =>
{

    if (await db.Students.FindAsync(id) is Student student)
        return Results.Ok(student);
    else return Results.NotFound();

});


app.MapPost("/students", async (Student student, StudentDb db) =>
{ 
    db.Students.Add(student);
    await db.SaveChangesAsync();
    return Results.Created($"/students/{student.Id}", student);
}
 );

app.MapPut("/students/{id}", async (int id, Student changedStudent, StudentDb db) =>
{
    var student = await db.Students.FindAsync(id);
    if(student is null) return Results.NotFound();

    student.Name = changedStudent.Name;
    student.IsReady = changedStudent.IsReady;
    //.....

    await db.SaveChangesAsync();
    return Results.Ok(); // $"/students/{student.Id}", student);
}
 );

app.MapDelete("/students/{id}", async (int id, StudentDb db) =>
{

    var student = await db.Students.FindAsync(id);
    if (student is null) return Results.NotFound();

    db.Students.Remove(student);
    await db.SaveChangesAsync();
    return Results.NoContent();
}
 );


app.MapGet("/api", () => "Hello Api Test!");

app.Run();
