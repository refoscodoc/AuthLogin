using Auth_Validator_MediatR.Commands;
using Auth_Validator_MediatR.DataAccess;
using Auth_Validator_MediatR.Models;
using MediatR;

namespace Auth_Validator_MediatR.Handlers;

public class AddUserHandler : IRequestHandler<AddUserCommand, UserModel>
{
    private readonly UserContext _context;

    public AddUserHandler(UserContext context)
    {
        _context = context;
    }

    public async Task<UserModel> Handle(AddUserCommand request, CancellationToken cancellationToken)
    {
        UserModel newUser = new UserModel
        {
            Id = Guid.NewGuid(),
            FirstName = request.FirstName,
            LastName = request.LastName,
            User = request.Username,
            Password = request.Password,
            Balance = 0,
            RegistrationDate = DateTime.Now
        };
        
        await _context.UsersTable.AddAsync(newUser);
        await _context.SaveChangesAsync();
        return newUser;
    }
}