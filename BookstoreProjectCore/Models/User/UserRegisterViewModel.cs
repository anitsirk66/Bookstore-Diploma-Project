using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace BookstoreWebApp.Models.User
{
    public class UserRegisterViewModel
    {
        [Required(ErrorMessage = "This field is required.")]
        [StringLength(20, MinimumLength = 6, ErrorMessage = "The username must be a minimum of 6 and a maximum of 20 characters.")]
        [RegularExpression(@"^\S*$", ErrorMessage = "No spaces are allowed.")]
        public string UserName { get; set; } = null!;

        [Required(ErrorMessage = "This field is required.")]
        [EmailAddress(ErrorMessage = "Invalid email adress.")]
        [StringLength(60, MinimumLength = 10, ErrorMessage = "The email must be a minimum of 10 and a maximum of 60 characters.")]
        [RegularExpression(@"^\S*$", ErrorMessage = "No spaces are allowed.")]
        public string Email { get; set; } = null!;

        [Required(ErrorMessage = "This field is required.")]
        [StringLength(20, MinimumLength = 6, ErrorMessage = "The password must be a minimum of 6 and a maximum of 20 characters.")]
        [DataType(DataType.Password, ErrorMessage = "Invalid password.")]
        [RegularExpression(@"^\S*$", ErrorMessage = "No spaces are allowed.")]
        public string Password { get; set; } = null!;

        [Compare(nameof(Password), ErrorMessage = "The passwords do not match.")]
        [DataType(DataType.Password, ErrorMessage = "Invalid password.")]
        public string ConfirmPassword { get; set; } = null!;

    }
}
