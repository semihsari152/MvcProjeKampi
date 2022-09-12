using MvcProjeKampi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProjeKampi.Controllers
{
    public class ChartController : Controller
    {
        // GET: Chart
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult CategoryChart()
        {
            return Json(BlogList(), JsonRequestBehavior.AllowGet);

        }

        List<CategoryClass> BlogList()
        {
            List<CategoryClass> ct = new List<CategoryClass>();

            ct.Add(new CategoryClass()
            {
                CategoryName = "Yazılım",
                CategoryCount = 8
            });
            ct.Add(new CategoryClass()
                 {
                     CategoryName = "Seyahat",
                     CategoryCount = 1
            });
            ct.Add(new CategoryClass()
            {
                CategoryName = "Spor",
                CategoryCount = 7
            });
            ct.Add(new CategoryClass()
            {
                CategoryName = "Teknoloji",
                CategoryCount = 4
            });
            return ct;
        }
    }
}