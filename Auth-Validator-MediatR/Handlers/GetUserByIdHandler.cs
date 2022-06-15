using Auth_Validator_MediatR.DataAccess;
using Auth_Validator_MediatR.Models;
using Auth_Validator_MediatR.Queries;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Auth_Validator_MediatR.Handlers;

public class GetUserByIdHandler : IRequestHandler<GetUserByIdQuery, UserModel>
{
    private readonly UserContext _context;

    public GetUserByIdHandler(UserContext context)
    {
        _context = context;
    }

    public async Task<UserModel> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
    {
        var user = await _context.UsersTable.FirstOrDefaultAsync(x => x.Id == request.UserId);
        return user;
    }
}