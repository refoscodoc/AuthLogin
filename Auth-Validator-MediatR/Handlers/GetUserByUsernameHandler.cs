using Auth_Validator_MediatR.DataAccess;
using Auth_Validator_MediatR.Models;
using Auth_Validator_MediatR.Queries;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Auth_Validator_MediatR.Handlers;

public class GetUserByUsernameHandler : IRequestHandler<GetUserByUsernameQuery, UserModel>
{
    private readonly UserContext _context;

    public GetUserByUsernameHandler(UserContext context)
    {
        _context = context;
    }

    public async Task<UserModel> Handle(GetUserByUsernameQuery request, CancellationToken cancellationToken)
    {
        var user = await _context.UsersTable.FirstOrDefaultAsync(x => x.Username == request.Username, cancellationToken);
        return user;
    }
}