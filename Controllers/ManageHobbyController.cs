using mvcdrc.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace mvcdrc.Controllers
{
    public class ManageHobbyController : Controller
    {

        DatabaseContext _db = new DatabaseContext();
        public ActionResult AddHobby()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddHobby(tblhobby _hb)
        {
            _db.tblhobbies.Add(_hb);
            _db.SaveChanges();
            return RedirectToAction("ShowHobby");
        }
        public ActionResult ShowHobby()
        {
            var data = _db.tblhobbies.ToList();
            return View(data);
        }
    }
}