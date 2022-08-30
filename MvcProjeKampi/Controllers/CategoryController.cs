using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProjeKampi.Controllers
{
    public class CategoryController : Controller
    {
        // GET: Category

        CategoryManager cm = new CategoryManager(new EfCategoryDal());

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GetCategoryList()
        {
            var categoryvalues = cm.GetList();

            return View(categoryvalues);
        }

        [HttpGet]//sayfa yüklendiği zaman 
        public ActionResult AddCategory()
        {
            return View();
        }


        [HttpPost] // sayfada bir butona tıkladığım zaman , sayfada bir şey post edildiği zaman sen çalışacaksın
        public ActionResult AddCategory(Category p)
        {

            CategoryValidator categoryValidator = new CategoryValidator();

            ValidationResult results = categoryValidator.Validate(p); // validasyonu kontrol ediyo

            if (results.IsValid)
            {
                cm.CategoryAdd(p);
                return RedirectToAction("GetCategoryList");
            }
            else
            {
                foreach (var item in results.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }

            return View();
        }




    }
}