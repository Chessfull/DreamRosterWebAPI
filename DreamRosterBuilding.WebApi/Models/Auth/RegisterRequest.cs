using System.ComponentModel.DataAnnotations;

namespace DreamRosterBuilding.WebApi.Models.Auth
{
    public class RegisterRequest // -> Single responsibility! Created for register request processes from user with model validations
    {
        [Required(ErrorMessage = "{0} is necessary field.")]
        [EmailAddress]
        [StringLength(80, ErrorMessage = "Email length must be between {2} and {1}.", MinimumLength = 8)]
        public string Email { get; set; }
        [Required(ErrorMessage = "{0} is necessary field.")]
        [StringLength(30, ErrorMessage = "Password length must be between {2} and {1}.", MinimumLength = 8)]
        public string Password { get; set; }
        [Required(ErrorMessage = "{0} is necessary field.")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "{0} is necessary field.")]
        public string LastName { get; set; }
        [Required(ErrorMessage = "{0} is necessary field.")]
        public DateTime Birthdate { get; set; }
    }
}
