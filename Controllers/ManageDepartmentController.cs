using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using mvcdrc.Models;

namespace mvcdrc.Controllers
{
    public class ManageDepartmentController : Controller
    {
        DatabaseContext _db = new DatabaseContext();
        public ActionResult AddDepartment()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddDepartment(tbldepartment _dpt)
        {
            _db.tbldepartments.Add(_dpt);
            _db.SaveChanges();
            return RedirectToAction("ShowDepartment");
        }
        public ActionResult ShowDepartment()
        {
            var data = _db.tbldepartments.ToList();
            return View(data);
        }
    }
}