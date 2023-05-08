using Employee.Abstraction;
using Employee.Entities;
using Employee.ViewModel.Enums;
using FishForoshi.Abstraction;

namespace Employee.Implementation
{
    public class WifeAction : IWifeAction
    {
        private readonly ICud<Wife> _action;
        private readonly IQuery<Wife> _query;

        public WifeAction(ICud<Wife> action, IQuery<Wife> query)
        {
            _action = action;
            _query = query;
        }

        public async Task<ActionStatus> CreateAsync(Wife wife)
        {
            return await _action.AddAsync(wife) ? ActionStatus.Success : ActionStatus.Failed;

        }

        public async Task<ActionStatus> DeleteAsync(Guid id)
            => await _action.DeleteByIdAsync(id)
                                ? ActionStatus.Success
                                : ActionStatus.Failed;

        public async Task<ActionStatus> UpdateAsync(Wife wife)
        {
            var model = await _query.GetAsync(wife.Id);
            if (model is null)
            {
                return ActionStatus.NotFound;
            }

            model.FirstName = wife.FirstName;
            model.LastName = wife.LastName;
            model.FatherName = wife.FatherName;
            model.BirthDate = wife.BirthDate;
            model.EmployeeId = wife.EmployeeId;
            model.MahaleSodoreShenasname = wife.MahaleSodoreShenasname;
            model.NationalCode = wife.NationalCode;

            return await _action.UpdateAsync(model)
                            ? ActionStatus.Success
                            : ActionStatus.Failed;
        }
    }
}
