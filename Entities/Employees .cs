using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Staff_Management.Entities
{
    [Table("employees")]
    public class Employees
    {
        [Key]
        [Column("id")]
        public int Id { get; set; } //abstract property

        [Column("name")]
        [Required]
        public string Name { get; set; }

        [Column("email")]
        [Required]
        public string Email { get; set; }

        // Foreign Key
        [Column("department_id")]
        public int DepartmentId { get; set; }

        // Navigation Property
        [ForeignKey("DepartmentId")]
        public Departments Department { get; set; }
    }
}
