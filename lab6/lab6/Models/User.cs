using System.ComponentModel.DataAnnotations;

namespace Lab6.Models;

public class User
{
    [Key]
    public string Id { get; set; } = default!;

    [Required(ErrorMessage = "Username is required")]
    [StringLength(50, ErrorMessage = "Username cannot be longer than 50 characters")]
    public string UserName { get; set; } = default!;

    [Required(ErrorMessage = "Full name is required")]
    [StringLength(500, ErrorMessage = "Full name cannot be longer than 500 characters")]
    public string FullName { get; set; } = default!;

    [Required(ErrorMessage = "Email address is required")]
    [EmailAddress(ErrorMessage = "Invalid email address")]
    public string Email { get; set; } = default!;

    [Required(ErrorMessage = "Phone number is required")]
    [RegularExpression(@"^\d{9}$", ErrorMessage = "Please enter exactly 9 digits for the phone number")]
    public string PhoneNumber { get; set; } = default!;
}
