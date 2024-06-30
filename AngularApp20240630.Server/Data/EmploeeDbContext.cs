using Microsoft.EntityFrameworkCore;
using AngularApp20240630.Server.Data.Model;

namespace AngularApp20240630.Server.Data
{
    public class EmploeeDbContext : DbContext
    {
        public DbSet<Emploee> Emploees { get; set; }

        public EmploeeDbContext(DbContextOptions<EmploeeDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            List<Emploee> emploees = new List<Emploee>();

            emploees.Add(new Emploee
            {
                Id = 1,
                FirstName = "Иван",
                MiddleName = "Иванович",
                LastName = "Иванов",
                Department = "Отдел разработки",
                Salary = 100000.00m,
                BirthDate = new DateTime(1980, 7, 20),
                HireDate = new DateTime(2010, 1, 2),

            });

            emploees.Add(new Emploee
            {
                Id = 2,
                FirstName = "Алексей",
                MiddleName = "Петрович",
                LastName = "Трегубов",
                Department = "Отдел тестирования",
                Salary = 80000.50m,
                BirthDate = new DateTime(1990, 4, 10),
                HireDate = new DateTime(2015, 7, 20),


            });

            emploees.Add(new Emploee
            {
                Id = 3,
                FirstName = "Андрей",
                MiddleName = "Юрьевич",
                LastName = "Петренко",
                Department = "Отдел разработки",
                Salary = 200000.00m,
                BirthDate = new DateTime(1980, 7, 20),
                HireDate = new DateTime(2015, 7, 20),


            });

            emploees.Add(new Emploee
            {
                Id = 4,
                FirstName = "Петр",
                MiddleName = "Петрович",
                LastName = "Петров",
                Department = "Отдел сопровождения",
                Salary = 150400.17m,
                BirthDate = new DateTime(1986, 8, 22),
                HireDate = new DateTime(2018, 12, 21),


            });

            emploees.Add(new Emploee
            {
                Id = 5,
                FirstName = "Сергей",
                MiddleName = "Сергеевич",
                LastName = "Сергеев",
                Department = "Дирекция",
                Salary = 360000.00m,
                BirthDate = new DateTime(1979, 3, 18),
                HireDate = new DateTime(2007, 9, 26),


            });

            emploees.Add(new Emploee
            {
                Id = 6,
                FirstName = "Анна",
                MiddleName = "Алексеевна",
                LastName = "Юровская",
                Department = "Отдел кадров",
                Salary = 170000.00m,
                BirthDate = new DateTime(1983, 10, 15),
                HireDate = new DateTime(2015, 7, 20),

            });

            modelBuilder.Entity<Emploee>().HasData(emploees);
        }
    }
}
