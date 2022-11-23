using System.ComponentModel.DataAnnotations;

namespace WebApplication2.Models.DTO
{
    public class LoginDTO
    {
        [Required]
        public string Username { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
