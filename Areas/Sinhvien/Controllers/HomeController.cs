using Microsoft.AspNetCore.Mvc;

namespace DATN_TMS.Areas.Sinhvien.Controllers
{
    [Area("Sinhvien")]
    public class HomeController : Controller
    {
        public IActionResult Index() => View();
    }
}
