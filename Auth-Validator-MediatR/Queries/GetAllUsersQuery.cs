using Auth_Validator_MediatR.Models;
using MediatR;

namespace Auth_Validator_MediatR.Queries;

public class GetAllUsersQuery : IRequest<List<UserModel>>
{
    
}