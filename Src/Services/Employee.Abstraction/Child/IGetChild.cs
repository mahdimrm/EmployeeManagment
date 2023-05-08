using Employee.Entities;

namespace Employee.Abstraction
{
    public interface IGetChild
    {
        Task<IEnumerable<Child>> GetEmployeeChildren(Guid employeeId);
        Task<Child> GetAsync(Guid id);
    }
}
