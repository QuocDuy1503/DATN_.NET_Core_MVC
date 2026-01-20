using Microsoft.AspNetCore.Mvc;

namespace DATN_TMS.Areas.Sinhvien.Controllers
{
    [Area("Sinhvien")]
    public class QL_DotDoAnController : Controller
    {
        public IActionResult DK_NV()
        {
            return View();
        }
        public IActionResult DX_DT()
        {
            return View();
        }
        public IActionResult DK_DT()
        {
            return View();
        }
        public IActionResult XCT_DT(int id)
        {
            return View();
        }
        public IActionResult XCT_DXDT(int id)
        {
            return View();
        }

    }
}
