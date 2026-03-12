using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace BookstoreWebApp.Models.User
{
    public class UserCreateAdminViewModel
    {
        [Required(ErrorMessage = "This field is required.")]
        [StringLength(20, MinimumLength = 6, ErrorMessage = "The username must be a minimum of 6 and a maximum of 20 characters.")]
        public string UserName { get; set; } = null!;

        [Required(ErrorMessage = "This field is required.")]
        [EmailAddress(ErrorMessage = "Invalid email adress.")]
        [StringLength(60, MinimumLength = 10, ErrorMessage = "The email must be a minimum of 10 and a maximum of 60 characters.")]
        public string Email { get; set; } = null!;

        [Required(ErrorMessage = "This field is required.")]
        [StringLength(20, MinimumLength = 6, ErrorMessage = "The password must be a minimum of 6 and a maximum of 20 characters.")]
        [DataType(DataType.Password, ErrorMessage = "Invalid password.")]
        public string Password { get; set; } = null!;

        [Compare(nameof(Password), ErrorMessage = "The passwords do not match.")]
        [DataType(DataType.Password, ErrorMessage = "Invalid password.")]
        public string ConfirmPassword { get; set; } = null!;

        [Required(ErrorMessage = "This field is required.")]
        public string Role { get; set; } = null!;

        public List<string> Roles { get; set; } = new List<string>();

        public IEnumerable<SelectListItem>? RolesList { get; set; } = new List<SelectListItem>();
    }
}
