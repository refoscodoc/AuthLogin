using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace Auth_Validator_MediatR.Models;

public class UserModel : IdentityUser
{
    [Key]
    public Guid Id { get; set; }
    public string User { get; set; }
    public string Password { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public double Balance { get; set; }
    public DateTime RegistrationDate { get; set; }

    public string Email { get; set; }
}