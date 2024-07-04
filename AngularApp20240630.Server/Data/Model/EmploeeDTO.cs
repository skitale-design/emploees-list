using System.ComponentModel.DataAnnotations.Schema;

namespace AngularApp20240630.Server.Data.Model
{
    internal class EmploeeDTO
    {
        public required string FirstName { get; set; }
        public required string LastName { get; set; }
        public string? MiddleName { get; set; }
        public required string Department { get; set; }
        public DateTime BirthDate { get; set; }
        public DateTime HireDate { get; set; }
        public decimal Salary { get; set; }
    }
}