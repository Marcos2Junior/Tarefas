using ControleTarefa.Data;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ControleTarefa.Repositorio.Interfaces;

namespace ControleTarefa.Repositorio.Repositorios
{
    public class TarefaRepositorio : ITarefaRepositorio
    {
        private readonly TarefasDataContext _context;

        public TarefaRepositorio(TarefasDataContext tarefasDataContext)
        {
            _context = tarefasDataContext;
        }
        public async Task<bool> AddAsync<T>(T entity) where T : class
        {
            await _context.Set<T>().AddAsync(entity);
            return await SaveChangesAsync();
        }

        public async Task<bool> DeleteAsync<T>(T entity) where T : class
        {
            _context.Remove(entity);
            return await SaveChangesAsync();
        }

        public async Task<bool> UpdateAsync<T>(T entity) where T : class
        {
            if (_context.Entry(entity).State == EntityState.Detached)
            {
                _context.Attach(entity);
                _context.Entry(entity).State = EntityState.Modified;
            }
            else
            {
                _context.Update(entity);
            }
            return await SaveChangesAsync();
        }

        private async Task<bool> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync() > 0;
        }
    }
}
