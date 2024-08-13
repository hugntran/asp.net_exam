using System.ComponentModel.DataAnnotations;

namespace Staff_Management.ViewModels
{
    public class CreateEmployeeViewModel
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public int DepartmentId { get; set; }
    }
}
