using Lab10_Marquez.Application.Ports;
using Lab10_Marquez.Domain.Entities;
using Lab10_Marquez.Infrastructure.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace Lab10_Marquez.Infrastructure.Adapters;

public class UserRepository : GenericRepository<User>, IUserRepository
{
    public UserRepository(Lab10DbContext context) : base(context)
    {
    }

    public async Task<User?> GetByUsernameAsync(string username)
    {
        return await _context.Users
            .FirstOrDefaultAsync(u => u.Username == username);
    }
}