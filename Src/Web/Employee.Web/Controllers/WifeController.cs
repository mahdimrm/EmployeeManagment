using Employee.Entities;

namespace Employee.Web.Controllers
{
    public class WifeController : BaseController
    {
        private readonly IGetWife _query;
        private readonly IWifeAction _action;
        private readonly IGetEmployee _employeeQuery;

        public WifeController(IGetWife query, IWifeAction action, IGetEmployee employeeQuery)
        {
            _query = query;
            _action = action;
            _employeeQuery = employeeQuery;
        }

        public async Task<IActionResult> Index(Guid employeeId)
        {
            ViewBag.employeeId = employeeId;
            return View(await _query.GetEmployeeWifes(employeeId));
        }

        [HttpGet]
        public async Task<IActionResult> Create(Guid employeeId)
        {
            var employee = await _employeeQuery.GetAsync(employeeId);
            ViewBag.employeeFullName = $"{employee.FirstName + " " + employee.LastName}";
            ViewBag.employeeId = employeeId;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Wife wife)
        {
            var result = await _action.CreateAsync(wife);
            if (result == ActionStatus.Success)
            {
                TempData[SuccessMessage] = "عملیات با موفقیت انجام شد ";
                return Redirect($"/Wife/Index?employeeId={wife.EmployeeId}");
            }
            TempData[ErrorMessage] = "خطا";
            return Ok();
        }

        [HttpGet]
        public async Task<IActionResult> Edit(Guid id)
        {
            var wife = await _query.GetAsync(id);
            if (wife is null)
            {
                TempData[ErrorMessage] = "خطا";
                return Ok();
            }
            return View(wife);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Wife wife)
        {
            var result = await _action.UpdateAsync(wife);
            if (result == ActionStatus.Success)
            {
                TempData[SuccessMessage] = "عملیات با موفقیت انجام شد ";
                return Redirect($"/Wife/Index?employeeId={wife.EmployeeId}");
            }
            TempData[ErrorMessage] = "خطا";
            return Ok();
        }

        [HttpGet]
        public async Task<IActionResult> Delete(Guid id)
        {
            var wife = await _query.GetAsync(id);
            if (wife is null)
            {
                return NotFound();
            }
            return View(wife);
        }

        public async Task<IActionResult> ConfirmationDelete(Guid id)
        {
            var result = await _action.DeleteAsync(id);
            if (result == ActionStatus.Success)
            {
                TempData[SuccessMessage] = "عملیات با موفقیت انجام شد ";
                return Redirect(HttpContext.Request.Headers["Referer"]);
            }
            TempData[ErrorMessage] = "خطا";
            return View();
        }
    }
}
