using System;
using System.Linq;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using PizzaShop.Models;
using PizzaShop.Models.Model;
using Shop.Models.Repository;

namespace Shop.Controllers
{
    public class OrderController : Controller
    {
        UnitOfWork unitOfWork = new UnitOfWork();

        public ActionResult MakeOrder()
        {
           
            return PartialView();
        }
        public ActionResult AddToCart(int id)
        {

            unitOfWork.Orders.Create(new Cart
            {
                EmailUser = User.Identity.Name,
                ProductId = id,
                PurchaseDate = DateTime.Now,
                Quantity = 1
            });
             
                unitOfWork.Save();
            
            return PartialView("OrderPartial");
        }

        public ActionResult AllUserOrders()
        {
            return View(unitOfWork.Orders.GetUserOrders(User.Identity.Name).ToList());
        }

        public ActionResult Remove(int ide)
        {
            unitOfWork.Orders.Remove(ide);
            unitOfWork.Save();
            return PartialView();
        }
    }
}