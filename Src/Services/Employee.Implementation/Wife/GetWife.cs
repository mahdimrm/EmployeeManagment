using Employee.Abstraction;
using Employee.Entities;
using FishForoshi.Abstraction;

namespace Employee.Implementation
{
    public class GetWife : IGetWife
    {
        private readonly IQuery<Wife> _query;

        public GetWife(IQuery<Wife> query)
        {
            _query = query;
        }

        public async Task<Wife> GetAsync(Guid id)
            => await _query.GetAsync(id);

        public async Task<IEnumerable<Wife>> GetEmployeeWifes(Guid employeeId)
            => await _query.GetAllAsync(x => x.EmployeeId == employeeId);

        public async Task<IEnumerable<Wife>> GetWifes()
            => await _query.GetAllAsync();
    }
}
