using static System.Console;

namespace WebApp3
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            var app = builder.Build();

            // app.MapGet("/", () => "Hello World!");
            int counter = 0;
            app.Run(async (ctx) =>
            {   
               WriteLine($"Run salute: {++counter}");

                if (!ctx.Request.Cookies.ContainsKey("last_value"))
                {
                    ctx.Response.Cookies.Append("last_value", "123.456", 
                        new CookieOptions() {MaxAge = TimeSpan.FromSeconds(60) });
                    

                }
                else 
                    WriteLine("Cookiee set.");

                await ctx.Response.WriteAsync("Salute!!");
                await ctx.Response.WriteAsync("Salute2!!");
            }
            
            );

          //  app.Run(async (ctx) =>
          //  {
          //      WriteLine($"Run salute2: {++counter}");

          //      await ctx.Response.WriteAsync("Salute2!!");
          //  }

          //);


            app.Run();

           

        }
    }
}
