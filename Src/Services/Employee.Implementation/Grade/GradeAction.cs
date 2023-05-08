using Employee.Abstraction;
using Employee.Entities;
using Employee.ViewModel.Enums;
using FishForoshi.Abstraction;

namespace Employee.Implementation
{
    public class GradeAction : IGradeAction
    {
        private readonly IQuery<Grade> _query;
        private readonly ICud<Grade> _action;

        public GradeAction(IQuery<Grade> query, ICud<Grade> action)
        {
            _query = query;
            _action = action;
        }

        public async Task<ActionStatus> CreateAsync(Grade grade)
        {
            return await _action.AddAsync(grade) ? ActionStatus.Success : ActionStatus.Failed;
        }

        public async Task<ActionStatus> UpdateAsync(Grade grade)
        {
            var model = await _query.GetAsync(grade.Id);

            model.Name = grade.Name;

            return await _action.UpdateAsync(model)
                ? ActionStatus.Success : ActionStatus.Failed;
        }


        public async Task<ActionStatus> DeleteAsync(Guid id)
            => await _action.DeleteByIdAsync(id)
                                ? ActionStatus.Success
                                : ActionStatus.Failed;
    }
}
