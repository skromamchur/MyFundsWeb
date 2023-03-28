using System.ComponentModel.DataAnnotations;

namespace WebUI.Models
{
    public class CreateUserViewModel
    {
        [Required(ErrorMessage = "Login name is required")]
        public string Login { get; set; } = string.Empty;

        [Required(ErrorMessage = "Password is required")]
        [MinLength(6, ErrorMessage = "Password should be at least 6 characters long")]
        public string Password { get; set; } = string.Empty;
    }
}
