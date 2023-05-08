using Employee.Entities;
using System.Linq.Expressions;

namespace FishForoshi.Abstraction
{
    public interface IQuery<T> where T : BaseEntity
    {
        Task<IEnumerable<T>> GetAllAsync();
        Task<T> GetAsync(object? id);
        Task<IEnumerable<T>> GetAllAsync(Expression<Func<T, bool>> where);

    }
}
