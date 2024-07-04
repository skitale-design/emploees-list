using AngularApp20240630.Server.Data;
using AngularApp20240630.Server.Data.Model;
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
                    builder => builder.WithOrigins("https://localhost:4200", "http://localhost:4200"));
            });

            builder.Services.AddDbContext<EmploeeDbContext>(x => x.UseSqlServer(builder.Configuration["ConnectionStrings:EmploeeDB"]));


            var app = builder.Build();

            app.UseCors("AllowSpecificOrigin");
            app.UseDefaultFiles();
            app.UseStaticFiles();

            // Configure the HTTP request pipeline.

            app.UseHttpsRedirection();
            app.UseAuthorization();

            app.MapGet("/emploees", async (EmploeeDbContext db) =>
            {
                var emloees = await db.Emploees.ToListAsync();
                return Results.Ok(emloees);

            });

            app.MapGet("/emploee/{id:int}", async (EmploeeDbContext db, int id) =>
            {
                var emploee = await db.Emploees.Where(x=>x.Id == id).ToListAsync();

                if (emploee != null)
                {
                    return Results.Ok(emploee);
                }
                else
                {
                    return Results.NotFound();
                }

            });

            app.MapPost("/create", async (EmploeeDbContext db, EmploeeDTO emploee) =>
            {
                Emploee newEmploee = new Emploee
                {
                    Id = 0,
                    FirstName = emploee.FirstName,
                    LastName = emploee.LastName,
                    MiddleName = emploee.MiddleName,
                    Department = emploee.Department,
                    BirthDate = emploee.BirthDate,
                    HireDate = emploee.HireDate,
                    Salary = emploee.Salary
                };

                db.Add(newEmploee);
                db.SaveChanges();

                var emploees = await db.Emploees.ToListAsync();

                return Results.Ok(emploees);

            });

            app.MapDelete("/{id:int}", async (EmploeeDbContext db, int id) =>
            {
                var emploee = await db.Emploees.Where(x => x.Id == id).FirstOrDefaultAsync();

                db.Remove(emploee);
                db.SaveChanges();

                var emloees = await db.Emploees.ToListAsync();

                return Results.Ok(emloees);

            });

            app.MapFallbackToFile("/index.html");

            app.Run("http://localhost:4242");
        }
    }
}
