using System.ComponentModel.DataAnnotations;

namespace NASRAC.API.DTOs;

public class LoginDto
{
    [Required] public string Username { get; set; }

    [Required] public string Password { get; set; }
}