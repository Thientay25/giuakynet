using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;
using Microsoft.AspNetCore.Http;

namespace WebApplication1.Controllers
{
    public class MemberController : Controller
    {
        private MyDBContext _context;
        public MemberController(MyDBContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View(_context.KhachHangs.ToList());
        }
        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register(KhachHang user)
        {
            if (ModelState.IsValid)
            {
                _context.KhachHangs.Add(user);
                _context.SaveChanges();

                ModelState.Clear();
                ViewBag.Message = user.HoTen + " đã đăng kí thành công.";
            }
            return View();
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(KhachHang user)
        {
            var account = _context.KhachHangs.Where(u => u.Username == user.Username && u.Password == user.Password).FirstOrDefault();
            if (account != null)
            {
                HttpContext.Session.SetString("UserID", account.UserID.ToString());
                HttpContext.Session.SetString("Username", account.Username);
                return RedirectToAction("Welcome");
            }
            else
            {
                ModelState.AddModelError("", "Sai tên tài khoản hoặc mật khẩu.");
            }
            return View();
        }

        public ActionResult Welcome()
        {
            if (HttpContext.Session.GetString("UserID") != null)
            {
                ViewBag.Username = HttpContext.Session.GetString("Username");
                return View();
            }
            else
            {
                return RedirectToAction("Login");
            }
        }

        public ActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index");
        }
    }
}