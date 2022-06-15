using System.ComponentModel.DataAnnotations;

namespace Auth_Validator_MediatR.Dtos;

public class UserForAuthenticationDto
{
    [Required(ErrorMessage = "Email is required.")]
    public string? Email { get; set; }
    [Required(ErrorMessage = "Password is required.")]
    public string? Password { get; set; }
}
public class AuthResponseDto
{
    public bool IsAuthSuccessful { get; set; }
    public string? ErrorMessage { get; set; }
    public string? Token { get; set; }
}