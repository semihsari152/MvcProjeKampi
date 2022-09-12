using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProjeKampi.Controllers
{
    public class AuthorizationController : Controller
    {

        AdminManager adm = new AdminManager(new EfAdminDal());

        public ActionResult Index()
        {
            var adminvalues = adm.GetList();

            return View(adminvalues);
        }

        [HttpGet]
        public ActionResult AddAdmin()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddAdmin(Admin p)
        {
            adm.AdminAdd(p);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult EditAdmin(int id)
        {

            var adminvalue = adm.GetByID(id);
            return View(adminvalue);
        }

        [HttpPost]
        public ActionResult EditAdmin(Admin p)
        {

            adm.AdminUpdate(p);
            return RedirectToAction("Index");
        }
    }
}