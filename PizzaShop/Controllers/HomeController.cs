using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PizzaShop.Models;
using PizzaShop.Models.Model;
using Shop.Models.Repository;

namespace PizzaShop.Controllers
{
    public class HomeController : Controller
    {
       private UnitOfWork unitOfWork = new UnitOfWork();

        public ActionResult Index()
        {
            ViewBag.Images = unitOfWork.Products.GetFirst8();
            return View();
        }
        public ActionResult Menu(int ? id)
        {
            int page = id ?? 0;
            if (Request.IsAjaxRequest())
            {
                return PartialView("PartialMenu",unitOfWork.Products.GetItemsPage(page));
            }
            ViewBag.Images = unitOfWork.Products.GetFirst8();
            return View();
        }

        public ActionResult AutoComplete(string term)
        {
            return Json(unitOfWork.Products.AutoComplete(term), JsonRequestBehavior.AllowGet);
        }

        public ActionResult Contact()
        {
            return View();
        }

        public ActionResult About()
        {
            return View();
        }


        public ActionResult FeedBack()
        {
            ViewBag.Comment = unitOfWork.Comments.GetFirst8();
            return View();
        }

        public ActionResult AddComment(string message)
        {

            Comment comment = new Comment
                {
                    DateTime = DateTime.Now.ToLocalTime(),
                    Message = message,
                    UserEmail = User.Identity.Name
                };
                unitOfWork.Comments.Create(comment);
                unitOfWork.Save();
            

            return PartialView(comment);
        }
      
    }
}