using System.ComponentModel.DataAnnotations;

namespace BookstoreWebApp.Models.User
{
    public class UserLoginViewModel
    {
        [Required(ErrorMessage = "This field is required.")]
        [EmailAddress(ErrorMessage = "Invalid email adress.")]
        [StringLength(60, MinimumLength = 10, ErrorMessage = "The email must be a minimum of 10 and a maximum of 60 characters.")]
        public string Email { get; set; } = null!;

        [Required(ErrorMessage = "This field is required.")]
        [StringLength(20, MinimumLength = 6, ErrorMessage = "The password must be a minimum of 6 and a maximum of 20 characters.")]
        [DataType(DataType.Password, ErrorMessage = "Invalid password.")]
        public string Password { get; set; } = null!;

        [Required(ErrorMessage = "This field is required.")]
        public bool RememberMe { get; set; }
    }
}
