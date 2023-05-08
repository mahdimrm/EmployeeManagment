using Employee.Entities;

namespace FishForoshi.Abstraction
{
    public interface ICud<T> where T : BaseEntity
    {
        Task<bool> AddAsync(T entity);
        Task<bool> AddRangeAsync(IEnumerable<T> entity);
        Task<bool> UpdateAsync(T entity);
        Task<bool> UpdateRangeAsync(IEnumerable<T> entity);
        Task<bool> DeleteAsync(T entity);
        Task<bool> DeleteByIdAsync(Guid Guid);
        Task<bool> SaveAsync();
    }
}
