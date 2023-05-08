using Employee.Abstraction;
using Employee.Entities;
using Employee.ViewModel.Enums;
using FishForoshi.Abstraction;

namespace Employee.Implementation
{
    public class ChildAction : IChildAction
    {
        private readonly IQuery<Child> _query;
        private readonly ICud<Child> _action;

        public ChildAction(IQuery<Child> query, ICud<Child> action)
        {
            _query = query;
            _action = action;
        }

        public async Task<ActionStatus> CreateAsync(Child child)
        {
            return await _action.AddAsync(child) ? ActionStatus.Success : ActionStatus.Failed;

        }

        public async Task<ActionStatus> DeleteAsync(Guid id)
            => await _action.DeleteByIdAsync(id)
                                ? ActionStatus.Success
                                : ActionStatus.Failed;

        public async Task<ActionStatus> UpdateAsync(Child child)
        {
            var model = await _query.GetAsync(child.Id);
            if (model is null)
            {
                return ActionStatus.NotFound;
            }

            model.FirstName = child.FirstName;
            model.LastName = child.LastName;
            model.BirthDate = child.BirthDate;
            model.EmployeeId = child.EmployeeId;
            model.MahaleSodoreShenasname = child.MahaleSodoreShenasname;
            model.NationalCode = child.NationalCode;

            return await _action.UpdateAsync(model)
                            ? ActionStatus.Success
                            : ActionStatus.Failed;
        }
    }
}
