using Lab10_Marquez.Application.Ports;
using Lab10_Marquez.Infrastructure.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace Lab10_Marquez.Infrastructure.Adapters;

public class GenericRepository<T> : IGenericRepository<T> where T : class
{
    protected readonly Lab10DbContext _context;
    protected readonly DbSet<T> _dbSet;

    public GenericRepository(Lab10DbContext context)
    {
        _context = context;
        _dbSet = context.Set<T>();
    }

    public async Task<T?> GetByIdAsync(Guid id) => await _dbSet.FindAsync(id);

    public async Task<IEnumerable<T>> GetAllAsync() => await _dbSet.ToListAsync();

    public async Task AddAsync(T entity) => await _dbSet.AddAsync(entity);

    public void Update(T entity) => _dbSet.Update(entity);

    public void Delete(T entity) => _dbSet.Remove(entity);
}