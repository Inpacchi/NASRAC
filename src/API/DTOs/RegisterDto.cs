using System.ComponentModel.DataAnnotations;

namespace NASRAC.API.DTOs;

public class RegisterDto
{
    [Required] public string Username { get; set; }

    [Required] public string Email { get; set; }

    [Required] public string Password { get; set; }
}