using Employee.Entities;
using Employee.ViewModel.Enums;

namespace Employee.Abstraction
{
    public interface IGradeAction
    {
        Task<ActionStatus> CreateAsync(Grade grade);
        Task<ActionStatus> UpdateAsync(Grade grade);
        Task<ActionStatus> DeleteAsync(Guid id);
    }
}
