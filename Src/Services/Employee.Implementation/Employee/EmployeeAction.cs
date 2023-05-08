using Employee.Abstraction;
using Employee.Implementation.Common;
using Employee.ViewModel;
using Employee.ViewModel.Enums;
using FishForoshi.Abstraction;

namespace Employee.Implementation;

public class EmployeeAction : IEmployeeAction
{
    private readonly ICud<Entities.Employee> _action;
    private readonly IQuery<Entities.Employee> _query;

    public EmployeeAction(ICud<Entities.Employee> action, IQuery<Entities.Employee> query)
    {
        _action = action;
        _query = query;
    }

    public async Task<ActionStatus> CreateAsync(ActionEmployeeViewModel employee)
    {
        Entities.Employee newEmployee = new()
        {
            FirstName = employee.FirstName,
            LastName = employee.LastName,
            BirthDate = employee.BirthDate.ToDateTime(),
            PhoneNumber = employee.PhoneNumber,
            EmployedDateTime = employee.EmployedDateTime.ToDateTime(),
            Address = employee.Address,
            FatherName = employee.FatherName,
            PostCode = employee.PostCode,
            NationalCode = employee.NationalCode,
            GradeId = employee.GradeId,
            MahaleSodoreShenasname = employee.MahaleSodoreShenasname,
            TedadAeleBaEhtesabSarparast = employee.TedadAeleBaEhtesabSarparast,
            Type = employee.Type,
            PersonalCode = employee.PersonalCode,
            IsEngage = employee.IsEngage,
        };
        return await _action.AddAsync(newEmployee) ? ActionStatus.Success : ActionStatus.Failed;
    }

    public async Task<ActionStatus> DeleteAsync(Guid id)
        => await _action.DeleteByIdAsync(id)
                                ? ActionStatus.Success
                                : ActionStatus.Failed;

    public async Task<ActionStatus> UpdateAsync(ActionEmployeeViewModel employee)
    {
        var model = await _query.GetAsync(employee.Id);

        model.FirstName = employee.FirstName;
        model.LastName = employee.LastName;
        model.BirthDate = employee.BirthDate.ToDateTime();
        model.PhoneNumber = employee.PhoneNumber;
        model.EmployedDateTime = employee.EmployedDateTime.ToDateTime();
        model.Address = employee.Address;
        model.FatherName = employee.FatherName;
        model.PostCode = employee.PostCode;
        model.NationalCode = employee.NationalCode;
        model.GradeId = employee.GradeId;
        model.MahaleSodoreShenasname = employee.MahaleSodoreShenasname;
        model.TedadAeleBaEhtesabSarparast = employee.TedadAeleBaEhtesabSarparast;
        model.Type = employee.Type;
        model.PersonalCode = employee.PersonalCode;
        model.IsEngage = employee.IsEngage;

        return await _action.UpdateAsync(model)
            ? ActionStatus.Success : ActionStatus.Failed;
    }
}


