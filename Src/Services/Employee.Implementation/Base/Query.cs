using Employee.DataBase;
using Employee.Entities;
using FishForoshi.Abstraction;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Infrastructure.Implementation.Dal
{
    public class Query<T> : IQuery<T> where T : BaseEntity
    {
        private readonly EmployeeDbContext _context;
        private readonly DbSet<T> _dbset;

        public Query(EmployeeDbContext context)
        {
            _context = context;
            _dbset = context.Set<T>();
        }

        public async Task<IEnumerable<T>> GetAllAsync()
            => await _dbset.ToListAsync();

        public async Task<IEnumerable<T>> GetAllAsync(Expression<Func<T, bool>> where)
            => await _dbset.Where(where).ToListAsync();

        public async Task<T> GetAsync(object? id)
            => await _dbset.FindAsync(id);

    }
}
