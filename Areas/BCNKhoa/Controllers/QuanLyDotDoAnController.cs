using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DATN_TMS.Models;

namespace DATN_TMS.Areas.BCNKhoa.Controllers
{
    [Area("BCNKhoa")]
    public class QuanLyDotDoAnController : Controller
    {
        private readonly QuanLyDoAnTotNghiepContext _context;

        public QuanLyDotDoAnController(QuanLyDoAnTotNghiepContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            
            var danhSachDot = _context.DotDoAns
                .Include(d => d.IdKhoaHocNavigation) 
                .Include(d => d.IdHocKiNavigation)  
                .OrderByDescending(d => d.Id);   

            return View(await danhSachDot.ToListAsync());
        }
    }
}