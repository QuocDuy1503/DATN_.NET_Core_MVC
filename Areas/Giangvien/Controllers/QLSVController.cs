using Microsoft.AspNetCore.Mvc;

namespace DATN_TMS.Areas.Giangvien.Controllers
{
    [Area("Giangvien")]
    public class QLSVController : Controller
    {
        public IActionResult DSSV()
        {
            return View();
        }
        public IActionResult Nhatky()
        {
            return View();
        }
        public IActionResult Kehoach()
        {
            return View();
        }
    }
}
