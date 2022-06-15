using Auth_Validator_MediatR.Models;
using MediatR;

namespace Auth_Validator_MediatR.Queries;

public class GetUserByUsernameQuery : IRequest<UserModel>
{
    public readonly string Username;

    public GetUserByUsernameQuery(string username)
    {
        Username = username;
    }
}