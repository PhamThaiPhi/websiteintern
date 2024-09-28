using System;
using System.Linq;
using System.Web.Mvc;
using webintern.Models;

namespace webintern.Controllers
{
    public class HomeClientController : Controller
    {
        QLNSEntities1 database = new QLNSEntities1();

        // GET: HomeClient
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult UserProfile()
        {
            if (Session["MaNhanVien"] != null)
            {
                // Lấy mã nhân viên từ session
                if (int.TryParse(Session["MaNhanVien"].ToString(), out int maNhanVien))
                {
                    var nhanvienProfile = database.nhanviens.FirstOrDefault(d => d.ma_nhanvien == maNhanVien);

                    if (nhanvienProfile != null)
                    {
                        var viewModel = new ViewModel
                        {
                            Nhanvien = nhanvienProfile,
                        };

                        return View(viewModel);
                    }
                    else
                    {
                        return HttpNotFound();  // Trả về 404 nếu không tìm thấy nhân viên
                    }
                }
                else
                {
                    return RedirectToAction("Login", "LoginUser");
                }
            }
            else
            {
                return RedirectToAction("Login", "LoginUser");  // Chuyển hướng đến login nếu session là null
            }
        }

        public ActionResult AddNghiPhep()
        {
            if (Session["MaNhanVien"] != null)
            {
                // Lấy mã nhân viên từ session
                if (int.TryParse(Session["MaNhanVien"].ToString(), out int maNhanVien))
                {
                    var model = new leave_requests
                    {
                        ma_nhanvien = maNhanVien
                    };

                    return View(model);
                }
                else
                {
                    return RedirectToAction("Login", "LoginUser");
                }
            }
            else
            {
                return RedirectToAction("Login", "LoginUser");
            }
        }



        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddNghiPhep(leave_requests model)
        {
            // Validate that the start date is not before the request date
            if (model.ngay_batdau < model.request_date)
            {
                ModelState.AddModelError("ngay_batdau", "The start date cannot be before the request date.");
            }

            // Validate that the end date is not before the start date
            if (model.ngay_ketthuc < model.ngay_batdau)
            {
                ModelState.AddModelError("ngay_ketthuc", "The end date cannot be before the start date.");
            }

            // Proceed if model is valid
            if (ModelState.IsValid)
            {
                // Set the status to "Chưa duyệt" (Pending)
                model.status = "Chưa duyệt";

                // Lưu yêu cầu nghỉ phép vào cơ sở dữ liệu
                database.leave_requests.Add(model);
                database.SaveChanges();

                return RedirectToAction("Index");
            }

            // Return to the view if validation fails
            return View(model);
        }




    }
}
