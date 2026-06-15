using Lab10_Marquez.Application.Ports;
using Lab10_Marquez.Infrastructure.Data.Context;

namespace Lab10_Marquez.Infrastructure.Adapters;

public class UnitOfWork : IUnitOfWork
{
    private readonly Lab10DbContext _context;
    public IUserRepository Users { get; private set; }

    public UnitOfWork(Lab10DbContext context)
    {
        _context = context;
        Users = new UserRepository(_context);
    }

    public async Task<int> CompleteAsync() => await _context.SaveChangesAsync();

    public void Dispose() => _context.Dispose();
}