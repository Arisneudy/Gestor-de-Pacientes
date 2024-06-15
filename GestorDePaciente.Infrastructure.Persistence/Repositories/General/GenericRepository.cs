using GestorDePaciente.Core.Application.Interfaces.Repositories.General;
using GestorDePaciente.Infrastructure.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;

namespace GestorDePaciente.Infrastructure.Persistence.Repositories.General;

public class GenericRepository<Entity> : IGenericRepository<Entity> where Entity : class
{

    private readonly ApplicationContext _context;

    public GenericRepository(ApplicationContext context)
    {
        _context = context;
    }

    public virtual async Task<Entity> AddAsync(Entity entity)
    {
        await _context.Set<Entity>().AddAsync(entity);
        await _context.SaveChangesAsync();
        return entity;
    }

    public virtual async Task UpdateAsync(Entity entity)
    {
        _context.Entry(entity).State = EntityState.Modified;
        await _context.SaveChangesAsync();
    }

    public virtual async Task DeleteAsync(Entity entity)
    {
        _context.Set<Entity>().Remove(entity);
        await _context.SaveChangesAsync();
    }

    public virtual async Task<List<Entity>> GetAllAsync()
    {
        return await _context.Set<Entity>().ToListAsync();
    }

    public virtual async Task<Entity> GetByIdAsync(int id)
    {
        return await _context.Set<Entity>().FindAsync(id);
    }

    public virtual async Task<List<Entity>> GetAllWithInclude(List<string> properties)
    {
        var query = _context.Set<Entity>().AsQueryable();

        foreach (var property in properties)
        {
            query = query.Include(property);
        }

        return await query.ToListAsync();
    }
}