using System;
using System.Linq;
using System.Web.Mvc;
using webintern.Models;

namespace webintern.Controllers
{
    public class LoginUserController : Controller
    {
        QLNSEntities1 database = new QLNSEntities1();

        // GET: LoginUser
        public ActionResult Login()
        {
            return View();
        }

        // Phương thức kiểm tra đăng nhập
        public ActionResult KiemTraDangNhap(string username, string password)
        {
            // Kiểm tra đăng nhập bằng tài khoản User
            var user = database.nhanviens.FirstOrDefault(u => u.email == username && u.Passwords == password);

            if (user != null)
            {
                // Lưu roles và ma_nhanvien vào session khi đăng nhập thành công
                Session["UserRoles"] = user.roles;            // Lưu vai trò vào session
                Session["MaNhanVien"] = user.ma_nhanvien;     // Lưu mã nhân viên vào session

                // Điều hướng dựa trên roles
                if (user.roles == 0)
                {
                    return RedirectToAction("Index", "Home");
                }
                else if (user.roles == 1)
                {
                    return RedirectToAction("Index", "HomeClient", new { area = "Admin" });
                }
            }

            // Nếu đăng nhập thất bại
            TempData["ErrorMessage"] = "Đăng nhập không thành công. Vui lòng kiểm tra lại thông tin đăng nhập.";
            return RedirectToAction("Login");
        }


        // Phương thức đăng xuất
        public ActionResult Logout()
        {
            // Xóa các biến session
            Session["UserRoles"] = null;
            Session["MaNhanVien"] = null;  // Xóa mã nhân viên khi đăng xuất
            Session.Clear();
            Session.Abandon();

            // Chuyển hướng về trang chủ hoặc trang login sau khi đăng xuất
            return RedirectToAction("Index", "HomeClient");
        }
    }
}
