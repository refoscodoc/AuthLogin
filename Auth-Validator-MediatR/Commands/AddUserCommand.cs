using Auth_Validator_MediatR.Models;
using MediatR;

namespace Auth_Validator_MediatR.Commands;

public class AddUserCommand : IRequest<UserModel>
{
    public Guid Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Username { get; set; }
    public string Password { get; set; }
}