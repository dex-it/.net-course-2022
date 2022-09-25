using System.ComponentModel.DataAnnotations.Schema;

namespace ModelsDb
{
    [Table(name: "employees")]
    public class EmployeeDb
    {
        [Column(name: "id")]
        public Guid Id { get; set; }
        [Column(name: "salary")]
        public int Salary { get; set; }

    }
}
