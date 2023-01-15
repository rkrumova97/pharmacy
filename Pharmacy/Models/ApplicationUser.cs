using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace Pharmacy.Models
{
    public class ApplicationUser 
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Username { get; set; }

        [Required]
        public string Password { get; set; }

        [Required]
        public bool IsActive { get; set; }

        [Required]
        public int MedicineId { get; set; }
    }
}