using Auth_Validator_MediatR.Models;
using MediatR;

namespace Auth_Validator_MediatR.Queries;

public class GetUserByIdQuery : IRequest<UserModel>
{
    public readonly Guid UserId;

    public GetUserByIdQuery(Guid userId)
    {
        UserId = userId;
    }
}