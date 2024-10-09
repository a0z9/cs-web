using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authentication;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Text;



var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

//builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
//    .AddCookie(
//    option =>
//    {
//        option.LoginPath = "/home/login";
//        option.AccessDeniedPath = "/home/denied";
//    }

//    );

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(
    options => {
        options.TokenValidationParameters = new TokenValidationParameters
        {
          ValidateIssuer = true,
          ValidateAudience = true,
          ValidIssuer = AOPtions.ISSUER,
          ValidAudience = AOPtions.AUDIENCE,
          
          ValidateLifetime = true,
         
          IssuerSigningKey = AOPtions.GetKey(),
          ValidateIssuerSigningKey = true
        };
    }
    
    
    );

//builder.Logging.

builder.Services.AddAuthorization();
var app = builder.Build();


// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseStaticFiles();

app.UseStatusCodePagesWithReExecute("/home/status","?id={0}");
app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();

public class AOPtions
{
    public const string ISSUER = "IKIT";
    public const string AUDIENCE = "Student";
    private const string key = "oqwieuoqwieu9127qwjlkajsnlkjlakjdlkjrqwljrlqkwjrlqwkrjlkjlkj";

    public static SymmetricSecurityKey GetKey() {

    return new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key));
    }
}