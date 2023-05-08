using Employee.Entities;

namespace Employee.Abstraction
{
    public interface IGetWife
    {
        Task<IEnumerable<Wife>> GetWifes();
        Task<IEnumerable<Wife>> GetEmployeeWifes(Guid employeeId);
        Task<Wife> GetAsync(Guid id);
    }
}
