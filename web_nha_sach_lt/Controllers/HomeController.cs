using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using web_nha_sach_lt.Models;
using web_nha_sach_lt.Data;
using Microsoft.EntityFrameworkCore;
using web_nha_sach_lt.Helpers;

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

        public IActionResult Register()
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

        // Hiển thị giỏ hàng
        public IActionResult Cart()
        {
            var cart = HttpContext.Session.GetObjectFromJson<List<CartItem>>("Cart") ?? new List<CartItem>();
            return View("Cart", cart);
        }

        // Thêm sách vào giỏ hàng
        public IActionResult AddToCart(int id)
        {
            var sach = _context.Sach.FirstOrDefault(s => s.MaSach == id);
            if (sach == null)
                return NotFound();

            var cart = HttpContext.Session.GetObjectFromJson<List<CartItem>>("Cart") ?? new List<CartItem>();

            var existingItem = cart.FirstOrDefault(x => x.MaSach == id);
            if (existingItem != null)
            {
                existingItem.SoLuong++;
            }
            else
            {
                cart.Add(new CartItem
                {
                    MaSach = sach.MaSach,
                    TieuDe = sach.TieuDe,
                    TacGia = sach.TacGia,
                    Gia = sach.Gia,
                    HinhAnh = sach.HinhAnh ?? "default.jpg",
                    SoLuong = 1
                });
            }

            HttpContext.Session.SetObjectAsJson("Cart", cart);
            return RedirectToAction("Cart");
        }



        // Xóa sách khỏi giỏ hàng
        public IActionResult RemoveFromCart(int id)
        {
            var cart = HttpContext.Session.GetObjectFromJson<List<CartItem>>("Cart");
            if (cart != null)
            {
                cart.RemoveAll(x => x.MaSach == id);
                HttpContext.Session.SetObjectAsJson("Cart", cart);
            }
            return RedirectToAction("Cart");
        }

    }
}


