using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using webintern.Models;

namespace webintern.Controllers
{
    public class HomeController : Controller
    {
        QLNSEntities1 database = new QLNSEntities1();
        public ActionResult Index()
        {
            return View(database.nhanviens.ToList());
        }
        public ActionResult AddNhanvien()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddNhanvien(nhanvien nv)
        {
            nv.roles = 0;
            database.nhanviens.Add(nv);
            database.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Edit(int id)
        {

            return View(database.nhanviens.Where(s => s.ma_nhanvien == id).FirstOrDefault());
        }
        [HttpPost]
        public ActionResult Edit(nhanvien nv)
        {
            database.Entry(nv).State = System.Data.Entity.EntityState.Modified;
            database.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Delete(int id)
        {
            return View(database.nhanviens.Where(s => s.ma_nhanvien == id).FirstOrDefault());
        }
        [HttpPost]
        public ActionResult Delete(int id, nhanvien nv)
        {
            nv = database.nhanviens.Where(s => s.ma_nhanvien == id).FirstOrDefault();
            database.nhanviens.Remove(nv);
            database.SaveChanges();
            return RedirectToAction("Index");
        }
        
    }
}