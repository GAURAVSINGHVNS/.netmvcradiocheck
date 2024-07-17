using mvcdrc.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace mvcdrc.Controllers
{
    public class ManageGenderController : Controller
    {
        DatabaseContext _db = new DatabaseContext();
        public ActionResult AddGender()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddGender(tblgender _gd)
        {
            _db.tblgenders.Add(_gd);
            _db.SaveChanges();
            return RedirectToAction("ShowGender");
        }
        public ActionResult ShowGender()
        {
            var data = _db.tblgenders.ToList();
            return View(data);
        }
    }
}