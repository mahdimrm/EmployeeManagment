using Employee.ViewModel;
using Employee.ViewModel.Enums;

namespace Employee.Abstraction
{
    public interface IEmployeeAction
    {
        Task< ActionStatus> CreateAsync(ActionEmployeeViewModel upsert);
        Task< ActionStatus> UpdateAsync(ActionEmployeeViewModel upsert);
        Task< ActionStatus> DeleteAsync(Guid id);
    }
}
