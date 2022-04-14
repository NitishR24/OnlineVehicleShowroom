using System.Collections.Generic;
using System.Threading.Tasks;

namespace VehicleShowroom.Api.Interfaces
{
    public interface IGenericRepository<T> where T : class
    {
        Task<IList<T>> GetAllAsync();
        Task<T> GetByIdAsync(int id);
        Task<bool> CreateAsync(T entity);
        Task<bool> UpdateAsync(int id, T entity);
        Task<bool> DeleteAsync(int id);
        Task<bool> DeleteCustAsync(int id);

    }
}
