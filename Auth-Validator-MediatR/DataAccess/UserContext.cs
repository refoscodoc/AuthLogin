using Auth_Validator_MediatR.Dtos;
using Auth_Validator_MediatR.Models;
using Microsoft.EntityFrameworkCore;

namespace Auth_Validator_MediatR.DataAccess;

public class UserContext : DbContext
{
    public UserContext(DbContextOptions<UserContext> options) : base(options) {}
    
    public DbSet<UserModel> UsersTable { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.Entity<UserModel>().HasKey(m => m.Id);

        base.OnModelCreating(builder);
    }
}