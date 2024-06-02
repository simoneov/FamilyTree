using System.ComponentModel.DataAnnotations;

namespace FamilyTree.Dto
{
    public class LoginDto
    {
        [Required(ErrorMessage = "Username required")]
        public string Username { get; set; }
        [Required(ErrorMessage = "Password required")]
        public string Password { get; set; }
    }
}
