using Employee.ViewModel;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Employee.Web.Controllers
{
    public class EmployeeController : BaseController
    {
        private readonly IGetEmployee _query;
        private readonly IEmployeeAction _action;
        private readonly IGetGrade _gradeQuery;

        public EmployeeController(IGetEmployee query, IEmployeeAction action, IGetGrade gradeQuery)
        {
            _query = query;
            _action = action;
            _gradeQuery = gradeQuery;
        }

        public async Task<IActionResult> Index(int page = 1, string search = null)
        {
            ViewBag.search = search;
            var result = await _query.GetAsync(page, search);
            return View(result);
        }

        public async Task<IActionResult> LongOfMilitaryServices()
        {
            var result = await _query.GetAsync();
            return View(result);
        }
        public async Task<IActionResult> BirthDate()
        {
            var result = await _query.GetEmployeesBirthDateAsync();
            return View(result);
        }


        [HttpGet]
        public async Task<IActionResult> Info(Guid id)
        {
            var grades = await _gradeQuery.GetGrades();
            List<SelectListItem> result = new();
            foreach (var item in grades)
            {
                result.Add(new SelectListItem { Text = item.Name, Value = item.Id.ToString() });
            }
            ViewBag.Grades = result;
            var employee = await _query.GetAsync(id);
            if (employee is null)
            {
                TempData[ErrorMessage] = "یافت نشد";
                return RedirectToAction("Index");
            }
            return View(employee);
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            var grades = await _gradeQuery.GetGrades();
            List<SelectListItem> result = new();
            foreach (var item in grades)
            {
                result.Add(new SelectListItem { Text = item.Name, Value = item.Id.ToString() });
            }
            ViewBag.Grades = result;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(ActionEmployeeViewModel employee)
        {
            var result = await _action.CreateAsync(employee);
            return EmployeeActionResult(result);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(Guid id)
        {
            var grades = await _gradeQuery.GetGrades();
            List<SelectListItem> result = new();
            foreach (var item in grades)
            {
                result.Add(new SelectListItem { Text = item.Name, Value = item.Id.ToString() });
            }
            ViewBag.Grades = result;
            var employee = await _query.GetAsync(id);
            if (employee is null)
            {
                TempData[ErrorMessage] = "یافت نشد";
                return RedirectToAction("Index");
            }
            return View(employee);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(ActionEmployeeViewModel employee)
        {
            var result = await _action.UpdateAsync(employee);
            return EmployeeActionResult(result);
        }

        [HttpGet]
        public async Task<IActionResult> Delete(Guid id)
        {
            var employee = await _query.GetAsync(id);
            if (employee is null)
            {
                return NotFound();
            }
            return View(employee);
        }
        public async Task<IActionResult> ConfirmationDelete(Guid id)
        {
            var result = await _action.DeleteAsync(id);
            return EmployeeActionResult(result);
        }

        public IActionResult EmployeeActionResult(ActionStatus status)
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
