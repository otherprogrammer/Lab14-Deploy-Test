using Lab10_Marquez.Domain.Entities;

namespace Lab10_Marquez.Application.Ports;

public interface IUserRepository : IGenericRepository<User>
{
    Task<User?> GetByUsernameAsync(string username);
}