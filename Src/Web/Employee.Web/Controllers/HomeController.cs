namespace Employee.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly IGetEmployee _query;

        public HomeController(IGetEmployee query)
        {
            _query = query;
        }

        public async Task<IActionResult> Index()
        {
            var birthDays = await _query.GetEmployeesBirthDateAsync();
            ViewBag.BirthDays = birthDays.Count();
            return View();
        }
    }
}