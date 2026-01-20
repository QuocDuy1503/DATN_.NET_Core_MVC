using Microsoft.AspNetCore.Mvc;

namespace DATN_TMS.Areas.Sinhvien.Controllers
{
    [Area("Sinhvien")]
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return RedirectToAction("DK_NV");
        }

        public IActionResult DK_NV()
        {
            return View("~/Areas/Sinhvien/Views/QL_DotDoAn/DK_NV.cshtml");
        }
    }

}
