using POS.Domain.Entities;
using System.Linq.Expressions;

namespace POS.Infrastructure.Persistences.Interfaces
{
    public interface IGenericRepository<T> where T : BaseEntity
    {
        IQueryable<T> GetAllQueryable();
        Task<IEnumerable<T>> GetAllAsync();
        Task<IEnumerable<T>> GetSelectAsync();
        Task<T> GetByIdAsync(int id);
        Task<bool> RegisterAsync(T entity);
        Task<bool> EditAsync(T entity);
        Task<bool> RemoveAsync(int id);
        /// <summary>
        /// Devolverme un queryable en base a una entidad que le este pasando
        /// </summary>
        /// <param name="filter"></param>
        /// <returns></returns>
        IQueryable<T> GetEntityQuery(Expression<Func<T, bool>>? filter = null);
        
    }
}
