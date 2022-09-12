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
    public class HeadingController : Controller
    {

        HeadingManager hm = new HeadingManager(new EfHeadingDal());
        CategoryManager cm = new CategoryManager(new EfCategoryDal()); // kategori seçmek için
        WriterManager wm = new WriterManager(new EfWriterDal());     //kimin yazdığını seçmek için

        public ActionResult Index()
        {
            var headingvalues = hm.GetList();
            return View(headingvalues);
        }


        public ActionResult HeadingReport()
        {
            var headingvalues = hm.GetList();
            return View(headingvalues);
        }




        [HttpGet]
        public ActionResult AddHeading()//dropdown yapcaz c#'daki adı combobox obilette şehir seçerken çıkan tablo
        {

            List<SelectListItem> valuecategory =(from x in cm.GetList()
                                                 select new SelectListItem
                                                 {
                                                     Text=x.CategoryName,
                                                     Value=x.CategoryID.ToString()
                                                 }).ToList();



            List<SelectListItem> writercategory = (from x in wm.GetList()
                                                  select new SelectListItem
                                                  {
                                                      Text = x.WriterName+""+x.WriterSurName,
                                                      Value = x.WriterID.ToString()
                                                  }).ToList();

            ViewBag.vlc = valuecategory;

            ViewBag.vlw = writercategory;

            return View();
        }

        [HttpPost]
        public ActionResult AddHeading(Heading p)
        {
            p.HeadingDate = DateTime.Parse(DateTime.Now.ToShortDateString());

            hm.HeadingAdd(p);
            return RedirectToAction("Index");

        }

        [HttpGet]
        public ActionResult EditHeading(int id)
        {

            List<SelectListItem> valuecategory = (from x in cm.GetList()
                                                  select new SelectListItem
                                                  {
                                                      Text = x.CategoryName,
                                                      Value = x.CategoryID.ToString()
                                                  }).ToList();



            ViewBag.vlc = valuecategory;


            var headingvalue = hm.GetById(id);

            return View(headingvalue);
        }

        [HttpPost]
        public ActionResult EditHeading(Heading p)
        {
            hm.HeadingUpdate(p);
            return RedirectToAction("Index");
        }
       

        public ActionResult ChangeStatHeading(int id)
        {
            var headingvalue = hm.GetById(id);

            if (headingvalue.HeadingStatus == false)
            {
                headingvalue.HeadingStatus = true;
            }
            else
            {
                headingvalue.HeadingStatus = false;
            }

            hm.HeadingDelete(headingvalue);

            return RedirectToAction("Index");
        }
    }
}