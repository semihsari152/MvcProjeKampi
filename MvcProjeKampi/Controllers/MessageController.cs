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
    public class MessageController : Controller
    {

        MessageManager mm = new MessageManager(new EfMessageDal());

        MessageValidator messagevalidator = new MessageValidator();

        public ActionResult Inbox()
        {
            var messagevalues = mm.GetListInbox();

            return View(messagevalues);
        }

        public ActionResult Sendbox()
        {
            var messagevalues = mm.GetListSendbox();

            return View(messagevalues);
        }


        [HttpGet]
        public ActionResult NewMessage()
        {
            return View();
        }

        [HttpPost]
        public ActionResult NewMessage(Message p)
        {
            ValidationResult results = messagevalidator.Validate(p);

            if (results.IsValid)
            {
                p.MessageDate = DateTime.Parse(DateTime.Now.ToShortDateString());

                mm.MessageAdd(p);
                return RedirectToAction("Index");
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

        public ActionResult GetInboxMessageDetails(int id)
        {
            var messagevalues = mm.GetById(id);
            return View(messagevalues);
        }

        public ActionResult GetSendboxMessageDetails(int id)
        {
            var messagevalues = mm.GetById(id);
            return View(messagevalues);
        }
    }
}