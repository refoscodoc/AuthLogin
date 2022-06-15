using System.ComponentModel.DataAnnotations;

namespace Auth_Validator_MediatR.Models;

public class UserModel
{
    [Key]
    public Guid Id { get; set; }
    public string Username { get; set; }
    public string Password { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public double Balance { get; set; }
    public DateTime RegistrationDate { get; set; }
}