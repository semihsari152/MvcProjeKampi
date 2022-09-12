using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace MvcProjeKampi.Controllers
{
    public class WriterPanelContentController : Controller

    {
        Context c = new Context();
        ContentManager cm = new ContentManager(new EfContentDal());

        public ActionResult MyContent(string p) // sessiondan gelen writer id bilgisini aldık burda 
        {

            Context c = new Context();

            p = (string)Session["WriterMail"];
            var writeridinfo = c.Writers.Where(x => x.WriterMail == p).Select(y => y.WriterID).FirstOrDefault();
            //bu sorgu taşınabilir mimariye

            var contentvalues = cm.GetListByWriter(writeridinfo);

            return View(contentvalues);
        }

        [HttpGet]
        public ActionResult AddContent(int id)
        {

            ViewBag.d = id;

            return View();
        }

        [HttpPost]
        public ActionResult AddContent(Content p)
        {
            string mail = (string)Session["WriterMail"];
            var writeridinfo = c.Writers.Where(x => x.WriterMail == mail).Select(y => y.WriterID).FirstOrDefault();
            p.ContentDate = DateTime.Parse(DateTime.Now.ToShortDateString());
            p.WriterID = writeridinfo;
            p.ContentStatus = true;

            cm.ContentAdd(p);
            return RedirectToAction("MyContent");
        }

       
    }
}
