using Employee.Entities;
using Employee.ViewModel.Enums;

namespace Employee.Abstraction
{
    public interface IChildAction
    {
        Task<ActionStatus> CreateAsync(Child child);
        Task<ActionStatus> UpdateAsync(Child child);
        Task<ActionStatus> DeleteAsync(Guid id);
    }
}
