using Employee.Entities;
using Employee.ViewModel.Enums;

namespace Employee.Abstraction
{
    public interface IWifeAction
    {
        Task<ActionStatus> CreateAsync(Wife wife);
        Task<ActionStatus> UpdateAsync(Wife wife);
        Task<ActionStatus> DeleteAsync(Guid id);
    }
}
