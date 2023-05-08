using Employee.Entities;

namespace Employee.Web.Controllers
{
    public class GradeController : BaseController
    {
        private readonly IGetGrade _query;
        private readonly IGradeAction _action;

        public GradeController(IGetGrade query, IGradeAction action)
        {
            _query = query;
            _action = action;
        }

        public async Task<IActionResult> Index()
            => View(await _query.GetGrades());

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Grade grade)
        {
            var result = await _action.CreateAsync(grade);
            return GradeActionResult(result);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(Guid id)
        {
            var grade = await _query.GetAsync(id);
            if (grade is null)
            {
                TempData[ErrorMessage] = "یافت نشد";
                return RedirectToAction("Index");
            }
            return View(grade);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Grade grade)
        {
            var result = await _action.UpdateAsync(grade);
            return GradeActionResult(result);
        }

        [HttpGet]
        public async Task<IActionResult> Delete(Guid id)
        {
            var grade = await _query.GetAsync(id);
            if (grade is null)
            {
                return NotFound();
            }
            return View(grade);
        }

        public async Task<IActionResult> ConfirmationDelete(Guid id)
        {
            var result = await _action.DeleteAsync(id);
            return GradeActionResult(result);
        }

        public IActionResult GradeActionResult(ActionStatus status)
        {
            switch (status)
            {
                case ActionStatus.Success:
                    TempData[SuccessMessage] = "عملیات با موفقیت انجام شد ";
                    return RedirectToAction("Index");
                case ActionStatus.Failed:
                    TempData[ErrorMessage] = "خطا";
                    return RedirectToAction("Index");
                default:
                    TempData[ErrorMessage] = "خطا";
                    return RedirectToAction("Index");
            }
        }
    }
}
