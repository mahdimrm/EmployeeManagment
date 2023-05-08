using Employee.Abstraction;
using Employee.Entities;
using FishForoshi.Abstraction;

namespace Employee.Implementation
{
    public class GetChild : IGetChild
    {
        private readonly IQuery<Child> _query;

        public GetChild(IQuery<Child> query)
        {
            _query = query;
        }

        public async Task<Child> GetAsync(Guid id)
            => await _query.GetAsync(id);

        public async Task<IEnumerable<Child>> GetEmployeeChildren(Guid employeeId)
            => await _query.GetAllAsync(x => x.EmployeeId == employeeId);
    }
}
