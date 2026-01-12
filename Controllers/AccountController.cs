using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DATN_TMS.Models; // Đảm bảo namespace đúng
using Microsoft.AspNetCore.Http; // Để dùng Session

namespace DATN_TMS.Controllers
{
    public class AccountController : Controller
    {
        private readonly QuanLyDoAnTotNghiepContext _context;

        public AccountController(QuanLyDoAnTotNghiepContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Login()
        {
            // Nếu đã đăng nhập rồi thì đá về trang chủ quản lý, không cần đăng nhập lại
            if (HttpContext.Session.GetString("UserEmail") != null)
            {
                return RedirectToAction("Index", "QuanLyDotDoAn");
            }
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(string email, string password)
        {
            // 1. Kiểm tra database: Tìm user có Email + Pass khớp + TrangThai đang hoạt động (1)
            // Lưu ý: Password trong DB của bạn đang là 'pass123' (chưa mã hóa), nên so sánh trực tiếp
            var user = await _context.NguoiDungs
                .Include(u => u.IdVaiTros)         // Join sang bảng trung gian
                .FirstOrDefaultAsync(u => u.Email == email && u.MatKhau == password && u.TrangThai == 1);

            if (user == null)
            {
                ViewBag.Error = "Tài khoản hoặc mật khẩu không chính xác!";
                return View();
            }

            // 2. Lấy quyền (Role) của user đó
            // Lấy vai trò đầu tiên tìm thấy. Nếu không có thì gán là "Guest"
            var roleInfo = user.IdVaiTros.FirstOrDefault();
            string roleCode = roleInfo?.MaVaiTro ?? "GUEST"; // Ví dụ: BCN_KHOA, GV, SV
            
            // 3. Lưu thông tin vào Session (Giống như cấp thẻ ra vào)
            HttpContext.Session.SetString("UserEmail", user.Email);
            HttpContext.Session.SetString("FullName", user.HoTen ?? "Người dùng");
            HttpContext.Session.SetString("Role", roleCode); // Lưu quyền để phân biệt Admin/SV
            HttpContext.Session.SetString("Avatar", user.AvatarUrl ?? "/images/default-avatar.png");

            // 4. Điều hướng về trang tương ứng theo quyền
            if (roleCode == "BCN_KHOA" || roleCode == "BO_MON")
            {
                return RedirectToAction("Index", "QuanLyDotDoAn"); // Trang Admin bạn đã làm
            }
            else if (roleCode == "GV")
            {
                // return RedirectToAction("Index", "GiangVien"); // Tạm thời chưa có thì về trang Admin test thử
                return RedirectToAction("Index", "QuanLyDotDoAn");
            }
            else if (roleCode == "SV")
            {
                // return RedirectToAction("Index", "SinhVien"); // Tạm thời chưa có thì về trang Admin test thử
                return RedirectToAction("Index", "QuanLyDotDoAn");
            }

            // Mặc định về trang Admin để test
            return RedirectToAction("Index", "QuanLyDotDoAn");
        }

        public IActionResult Logout()
        {
            HttpContext.Session.Clear(); // Xóa sạch session (Đăng xuất)
            return RedirectToAction("Login");
        }
    }
}