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

                if (!ctx.Request.Cookies.ContainsKey("my_id") )
                {

                    WriteLine("Cookiee my_id set!");

                    ctx.Response.Cookies.Append("my_id", $"{new Random().Next(1, 100_1000)}", 
                        new CookieOptions() {
                            MaxAge = TimeSpan.FromSeconds(15), SameSite=SameSiteMode.Lax });
                
                }
                else 
                    WriteLine("Cookiee my_id exists and not reset!!");

                if (!ctx.Request.Cookies.ContainsKey("my_data"))
                {
                    WriteLine("Cookiee my_data set!");
                    ctx.Response.Cookies.Append("my_data", $"{new Random().Next(1, 100_1000)}");
                }
                else
                    WriteLine("Cookiee my_data exists and not reset!!");


                await ctx.Response.WriteAsync("Cookiee test page, See F12 and console.");
            
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
