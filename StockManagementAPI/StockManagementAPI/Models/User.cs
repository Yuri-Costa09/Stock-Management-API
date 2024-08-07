using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace StockManagementAPI.Models
{
    public class User : IdentityUser
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(45)]
        public string Username { get; set; }
        [Required]
        [StringLength(100)]
        public string Email { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.UtcNow;

    }
}
