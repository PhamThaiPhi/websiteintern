using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using webintern.Models;

namespace webintern.Controllers
{
    public class LeaveRequestController : Controller
    {
        QLNSEntities1 database = new QLNSEntities1();

        // GET: LeaveRequest
        public ActionResult Index()
        {
            return View(database.leave_requests.ToList());
        }

        // GET: LeaveRequest/EditRequest/5
        // GET: LeaveRequest/EditRequest/5
        public ActionResult EditRequest(int id)
        {
            // Fetch the leave request from the database
            var leaveRequest = database.leave_requests.FirstOrDefault(lr => lr.leave_id == id);
            if (leaveRequest == null)
            {
                return HttpNotFound();
            }
            return View(leaveRequest);
        }

        // POST: LeaveRequest/EditRequest
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditRequest(leave_requests model)
        {
            // Fetch the existing record from the database
            var existingRequest = database.leave_requests.FirstOrDefault(lr => lr.leave_id == model.leave_id);
            if (existingRequest == null)
            {
                return HttpNotFound();
            }

            // Update only the fields that need to change
            existingRequest.status = model.status; // Update status
                                                   // You can include other fields you want to update if necessary.

            // Save changes to the database
            database.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}
