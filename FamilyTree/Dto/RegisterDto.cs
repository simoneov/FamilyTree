using System.ComponentModel.DataAnnotations;

namespace FamilyTree.Dto
{
    public class RegisterDto
    {
        [Required(ErrorMessage = "Username required")]
        public string Username { get; set; }
        [Required(ErrorMessage = "Password required")]
        public string Password { get; set; }
        [Required(ErrorMessage = "Email required")]
        public string Email { get; set; }
    }
}
