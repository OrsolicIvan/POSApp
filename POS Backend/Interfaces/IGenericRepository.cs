using System.Collections.Generic;
using System.Threading.Tasks;

namespace POS_Backend.Interfaces
{
    public interface IGenericRepository<T> where T : class
    {
        void Add(T entity);
        void Delete(T entity);
        T GetById(int id);
        void Update(T entity);
        Task<bool> SaveAllAsync();
        Task<T> GetEntityByIdAsync(int id);
        Task<IEnumerable<T>> GetAllEntitiesAsync();
    }
}
