using Employee.Abstraction;
using Employee.Abstraction.Common;
using Employee.Implementation.Common;
using Employee.ViewModel;
using FishForoshi.Abstraction;
using System.Xml.Linq;

namespace Employee.Implementation
{
    public class GetEmployee : IGetEmployee
    {
        private readonly IQuery<Entities.Employee> _query;

        public GetEmployee(IQuery<Entities.Employee> query)
        {
            _query = query;
        }

        public async Task<IEnumerable<Entities.Employee>> GetAsync()
            => await _query.GetAllAsync();

        public async Task<IPagedList<Entities.Employee>> GetAsync(int pageNumber, string search)
        {
            var employees = await _query.GetAllAsync();

            if (search != null)
            {
                search = search.Trim();
                employees = employees
                    .Where(x => x.FirstName.Contains(search) ||
                    x.LastName.Contains(search) ||
                    x.NationalCode.Contains(search) ||
                    x.PersonalCode.Contains(search) ||
                    x.PhoneNumber.Contains(search) ||
                    x.Type.Contains(search));

            }

            return new PagedList<Entities.Employee>(employees, pageNumber, 10);
        }

        public async Task<Entities.Employee> GetAsync(Guid? id)
            => await _query.GetAsync(id);

        public async Task<IEnumerable<Entities.Employee>> GetEmployeesBirthDateAsync()
        {
            var employees = await _query
                .GetAllAsync(x => x.BirthDate.Month == DateTime.Now.Month && x.BirthDate.Day == DateTime.Now.Day);

            return employees;
        }
    }
}
