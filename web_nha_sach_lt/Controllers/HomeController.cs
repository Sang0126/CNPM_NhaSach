using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using web_nha_sach_lt.Models;
using web_nha_sach_lt.Data;
using Microsoft.EntityFrameworkCore;

namespace web_nha_sach_lt.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly AppDbContext _context;

        public HomeController(ILogger<HomeController> logger, AppDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        // Trang chủ
        public IActionResult Index()
        {
            var sachList = _context.Sach.ToList();
            return View(sachList);
        }

        // Trang danh mục
        public IActionResult DanhMuc()
        {
            var sachList = _context.Sach.ToList();
            return View(sachList);
        }

        public IActionResult TrangChiTiet(int id)
        {
            var sach = _context.Sach.FirstOrDefault(s => s.MaSach == id);
            if (sach == null) return NotFound();
            return View(sach);
        }


        // Tìm kiếm sách theo tiêu đề hoặc tác giả
        public IActionResult Search(string q)
        {
            var results = _context.Sach
                .Where(s => s.TieuDe.Contains(q) || s.TacGia.Contains(q))
                .ToList();
            return View("Index", results);
        }

        public IActionResult Login()
        {
            return View();
        }

        public IActionResult VeChungToi()
        {
            return View();
        }

        public IActionResult LienHe()
        {
            return View();
        }

        // Trang privacy
        public IActionResult Privacy()
        {
            return View();
        }

        // Trang lỗi
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}


