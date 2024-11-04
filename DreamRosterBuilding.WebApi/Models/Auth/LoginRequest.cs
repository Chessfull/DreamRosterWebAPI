using System.ComponentModel.DataAnnotations;

namespace DreamRosterBuilding.WebApi.Models.Auth
{
    public class LoginRequest // -> Single responsibility! Request model for login processes
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
