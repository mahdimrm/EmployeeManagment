using Employee.Abstraction.Common;

namespace Employee.Abstraction
{
    public interface IGetEmployee
    {
        Task<IEnumerable<Entities.Employee>> GetAsync();
        Task<Entities.Employee> GetAsync(Guid? id);
        Task<IPagedList<Entities.Employee>> GetAsync(int pageNumber, string search);
        Task<IEnumerable<Entities.Employee>> GetEmployeesBirthDateAsync();
    }
}
