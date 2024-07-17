using mvcdrc.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace mvcdrc.Controllers
{
    public class ManageRegistrationController : Controller
    {
        DatabaseContext _db = new DatabaseContext();
        public ActionResult AddRegistratioin(int A =0)
        {
            ViewBag.BT = "submit data";
            tblregistration1 obj = new tblregistration1();
            obj.lstdept = _db.tbldepartments.ToList();
            obj.lstgender = _db.tblgenders.ToList();
            var HData = _db.tblhobbies.ToList();
            obj.lsthobby1 = HData.Select(x => new tblhobbyy1
            {
                hid = x.hid,
                hname = x.hname,
                ischecked = false
            }).ToList();

            if (A > 0)
            {
                var data = _db.tblregistrations.Where(m => m.rid == A).ToList();
                obj.rid = data[0].rid;
                obj.rname = data[0].rname;
                obj.remail = data[0].remail;
                obj.rpassword = data[0].rpassword;
                obj.rdepartment = data[0].rdepartment;
                obj.rgender = data[0].rgender;
                string[] arr = data[0].rhobbies.Split(',');
                foreach(var a in obj.lsthobby1)
                {
                    foreach(var b in arr)
                    {
                        if(a.hname == b)
                        {
                            a.ischecked = true;
                        }
                    }
                }
                ViewBag.BT = "Update Data";
            }
            return View(obj);
        }
        [HttpPost]
        public ActionResult AddRegistratioin(tblregistration1 _reg1)
        {
            string kk = "";
            foreach(var a in _reg1.lsthobby1)
            {
                if(a.ischecked== true)
                {
                    kk += a.hname + ",";
                }
            }
            kk = kk.TrimEnd(',');

            tblregistration _reg = new tblregistration();
            _reg.rname = _reg1.rname;
            _reg.remail = _reg1.remail;
            _reg.rpassword = _reg1.rpassword;
            _reg.rdepartment = _reg1.rdepartment;
            _reg.rgender = _reg1.rgender;
            _reg.rhobbies = kk;

            if (_reg1.rid > 0)
            {
                _reg.rid = _reg1.rid;
                _db.Entry(_reg).State = System.Data.Entity.EntityState.Modified;
            }
            else
            {
                _db.tblregistrations.Add(_reg);
            }

            _db.SaveChanges();
            return RedirectToAction("ShowRegistration");
        }
        public ActionResult DeleteRegistration(int A =0)
        {
            var data = _db.tblregistrations.Find(A);
            _db.tblregistrations.Remove(data);
            _db.SaveChanges();
            return RedirectToAction("ShowRegistration");
        }
        public ActionResult ShowRegistration(int A = 0)
        {
            var data = (from R in _db.tblregistrations
                        join G in _db.tblgenders on R.rgender equals G.gid
                        join D in _db.tbldepartments on R.rdepartment equals D.did
                        select new RegistrationJoin
                        {
                            rid = R.rid,
                            rname = R.rname,
                            remail = R.remail,
                            rpassword = R.rpassword,
                            rdepartment = D.dname,
                            rgender = G.gname,
                            rhobbies= R.rhobbies
                        }).ToList();
            return View(data);
        }
    }
}