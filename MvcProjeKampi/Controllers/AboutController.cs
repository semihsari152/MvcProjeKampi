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
    public class AboutController : Controller
    {

        AboutManager abm = new AboutManager(new EfAboutDal());

        public ActionResult Index()
        {
            var aboutvalues = abm.GetList();

            return View(aboutvalues);
        }

        [HttpGet]
        public ActionResult AddAbout()
        {
            return View();
        }


        [HttpPost]
        public ActionResult AddAbout(About p)
        {

            abm.AboutAdd(p);

            return RedirectToAction("Index");
        }

        public PartialViewResult AboutPartial()
        {
            return PartialView();
        }


        public ActionResult AboutActive(int id)
        {
            var aboutvalues = abm.GetByID(id);

            aboutvalues.AboutStatus = true;

            abm.AboutDelete(aboutvalues);

            return RedirectToAction("Index");
        }


        public ActionResult AboutPassive(int id)
        {
            var aboutvalues = abm.GetByID(id);

            aboutvalues.AboutStatus = false;

            abm.AboutDelete(aboutvalues);

            return RedirectToAction("Index");
        }

       
    }
}