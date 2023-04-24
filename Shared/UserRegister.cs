using System.ComponentModel.DataAnnotations;

namespace RecipePlanner.Shared;

public class UserRegister
{
    [Required, StringLength(25, MinimumLength = 6)]
    public string Name { get; set; } = string.Empty;
    [Required, EmailAddress]
    public string Email { get; set; } = string.Empty;
    [Required, StringLength(100, MinimumLength = 6)]
    public string Password { get; set; } = string.Empty;
    [Compare("Password", ErrorMessage = "Passwords do not match!")]
    public string ConfirmPassword { get; set; } = string.Empty;
}