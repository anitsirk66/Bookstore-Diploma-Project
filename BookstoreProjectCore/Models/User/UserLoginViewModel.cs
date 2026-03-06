using System.ComponentModel.DataAnnotations;

namespace BookstoreWebApp.Models.User
{
    public class UserLoginViewModel
    {
        [Required]
        [EmailAddress]
        [StringLength(60, MinimumLength = 10)]
        public string Email { get; set; } = null!;

        [Required]
        [StringLength(20, MinimumLength = 6)]
        [DataType(DataType.Password)]
        public string Password { get; set; } = null!;

        [Required]
        public bool RememberMe { get; set; }
    }
}
