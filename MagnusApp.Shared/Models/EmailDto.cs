using System.ComponentModel.DataAnnotations;
namespace MagnusApp.Shared.Models;

public class EmailDto
{
    [Required(ErrorMessage = "The field Name is required")]
    public string Subject { get; set; } = string.Empty;
    [Required(ErrorMessage = "Please enter an Email Address")]
    [EmailAddress(ErrorMessage = "Please enter a valid Email Address")]
    public string From { get; set; } = string.Empty;
    [Required(ErrorMessage = "Please enter a message")]
    public string Body { get; set; } = string.Empty;

}


