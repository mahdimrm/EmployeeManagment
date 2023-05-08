using Employee.Entities;

namespace Employee.Abstraction
{
    public interface IGetGrade
    {
        Task<IEnumerable<Grade>> GetGrades();
        Task<Grade> GetAsync(Guid id);
    }
}
