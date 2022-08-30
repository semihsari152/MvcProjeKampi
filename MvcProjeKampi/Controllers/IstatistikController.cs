using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProjeKampi.Controllers
{
    public class IstatistikController : Controller
    {

        Context context = new Context();


        public ActionResult Index()
        {
            var result = context.Categories.Count();
            ViewBag.deger = result;


            var result2 = context.Headings.Where(x => x.CategoryID == 31).Count();
            ViewBag.deger1 = result2;


            var result3 = context.Writers.Where(x => x.WriterName.Contains("A")).ToList().Count();
            ViewBag.deger3 = result3;


            var result4 = context.Categories.Where(p => p.CategoryID == context.Headings.GroupBy(x => x.CategoryID).OrderByDescending(x => x.Count()).Select(x => x.Key).FirstOrDefault()).Select(x => x.CategoryName).FirstOrDefault();

            ViewBag.deger4 = result4;


            var result5 = (context.Categories.Where(x => x.CategoryStatus == true).Count())- (context.Categories.Where(x => x.CategoryStatus == false).Count());
            ViewBag.deger5 = result5;


            return View();
        }
    }
}