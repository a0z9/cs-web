namespace WebApp5_mvc
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddDistributedMemoryCache();
            builder.Services.AddSession();

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            var app = builder.Build();

            app.UseSession(new SessionOptions() {IdleTimeout=TimeSpan.FromMinutes(1) });


            app.Environment.EnvironmentName = "Production";

            //Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error2");
            }

            app.UseStaticFiles();

            // /Home/Orders/25..    ?Page=Home&Table=Orders&Id=25....
            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.UseStatusCodePages("text/html","<h2>Error, Status: {0}</h2>");
            app.UseStatusCodePagesWithReExecute("/home/status","?id={0}");

            app.Run();
        }
    }
}
