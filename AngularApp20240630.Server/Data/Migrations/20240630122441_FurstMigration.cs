using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace AngularApp20240630.Server.Data.Migrations
{
    /// <inheritdoc />
    public partial class FurstMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Emploees",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MiddleName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Department = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BirthDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    HireDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Salary = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Emploees", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Emploees",
                columns: new[] { "Id", "BirthDate", "Department", "FirstName", "HireDate", "LastName", "MiddleName", "Salary" },
                values: new object[,]
                {
                    { 1, new DateTime(1980, 7, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "Отдел разработки", "Иван", new DateTime(2010, 1, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "Иванов", "Иванович", 100000.00m },
                    { 2, new DateTime(1990, 4, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Отдел тестирования", "Алексей", new DateTime(2015, 7, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "Трегубов", "Петрович", 80000.50m },
                    { 3, new DateTime(1980, 7, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "Отдел разработки", "Андрей", new DateTime(2015, 7, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "Петренко", "Юрьевич", 200000.00m },
                    { 4, new DateTime(1986, 8, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "Отдел сопровождения", "Петр", new DateTime(2018, 12, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), "Петров", "Петрович", 150400.17m },
                    { 5, new DateTime(1979, 3, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "Дирекция", "Сергей", new DateTime(2007, 9, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), "Сергеев", "Сергеевич", 360000.00m },
                    { 6, new DateTime(1983, 10, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Отдел кадров", "Анна", new DateTime(2015, 7, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "Юровская", "Алексеевна", 170000.00m }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Emploees");
        }
    }
}
