using Auth_Validator_MediatR.DataAccess;
using Auth_Validator_MediatR.Models;
using Auth_Validator_MediatR.Queries;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Auth_Validator_MediatR.Handlers;

public class GetAllUsersHandler : IRequestHandler<GetAllUsersQuery, List<UserModel>>
{
    private readonly UserContext _context;

    public GetAllUsersHandler(UserContext context)
    {
        _context = context;
        
    }
    public async Task<List<UserModel>> Handle(GetAllUsersQuery request, CancellationToken cancellationToken)
    {
        return await _context.UsersTable.Select(x => x).ToListAsync(cancellationToken);
    }
}