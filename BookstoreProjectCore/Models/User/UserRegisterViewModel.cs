using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace BookstoreWebApp.Models.User
{
    public class UserRegisterViewModel
    {
        [Required]
        [StringLength(20, MinimumLength = 6)]
        public string UserName { get; set; } = null!;

        [Required]
        [EmailAddress]
        [StringLength(60, MinimumLength = 10)]
        public string Email { get; set; } = null!;

        [Required]
        [StringLength(20, MinimumLength = 6)]
        [DataType(DataType.Password)]
        public string Password { get; set; } = null!;

        [Compare(nameof(Password))]
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; } = null!;

        [Required]
        public string Role { get; set; }
        public List<string> Roles { get; set; }
    }
}
