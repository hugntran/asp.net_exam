using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;

namespace Staff_Management.Entities
{
    [Table("departments")]
    public class Departments
    {
        [Key]
        [Column("id")]
        public int Id { get; set; } //abstract property

        [Column("name")]
        [Required]
        public string Name { get; set; }

        [Column("description")]
        [Required]
        public string Description { get; set; }

        // Navigation Property
        public ICollection<Employees> Employees { get; set; } = new List<Employees>();
    }
}
