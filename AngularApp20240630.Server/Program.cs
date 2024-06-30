using AngularApp20240630.Server.Data;
using Microsoft.EntityFrameworkCore;

namespace AngularApp20240630.Server
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddAuthorization();

            builder.Services.AddCors(options =>
            {
                options.AddPolicy("AllowSpecificOrigin",
                    builder => builder.WithOrigins("http://localhost:4200"));
            });

            builder.Services.AddDbContext<EmploeeDbContext>(x => x.UseSqlServer(builder.Configuration["ConnectionStrings:EmploeeDB"]));


            var app = builder.Build();

            app.UseCors("AllowSpecificOrigin");
            app.UseDefaultFiles();
            app.UseStaticFiles();

            // Configure the HTTP request pipeline.

            app.UseHttpsRedirection();

            app.UseAuthorization();

            var summaries = new[]
            {
                "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
            };

            app.MapGet("/weatherforecast", (HttpContext httpContext) =>
            {
                var forecast = Enumerable.Range(1, 5).Select(index =>
                    new WeatherForecast
                    {
                        Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                        TemperatureC = Random.Shared.Next(-20, 55),
                        Summary = summaries[Random.Shared.Next(summaries.Length)]
                    })
                    .ToArray();
                return forecast;
            });

            app.MapGet("/emploees", async (EmploeeDbContext db) =>
            {
                var emloees = await db.Emploees.ToListAsync();
                return Results.Json(new { emloees });
            });

            app.MapFallbackToFile("/index.html");

            app.Run();
        }
    }
}
