using Employee.Abstraction;
using Employee.Entities;
using FishForoshi.Abstraction;

namespace Employee.Implementation
{
    public class GetGrade : IGetGrade
    {
        private readonly IQuery<Grade> _query;

        public GetGrade(IQuery<Grade> query)
        {
            _query = query;
        }

        public async Task<IEnumerable<Grade>> GetGrades()
            => await _query.GetAllAsync();

        public async Task<Grade> GetAsync(Guid id)
            => await _query.GetAsync(id);
    }
}
