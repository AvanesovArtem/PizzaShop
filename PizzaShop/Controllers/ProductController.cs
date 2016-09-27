using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AutoMapper;
using PizzaShop.Models;
using PizzaShop.Models.Model;
using PizzaShop.Models.ViewModel;
using Shop.Models.Repository;

namespace Shop.Controllers
{
    [Authorize(Roles = "admin")]
    public class ProductController : Controller
    {
        private UnitOfWork unitOfWork = new UnitOfWork();
        // GET: Product
        public ActionResult Products()
        {
           
            ViewBag.Products = unitOfWork.Products.GetAll();
            return View();
        }

        public ActionResult Edit(int id)
        {
            return View(unitOfWork.Products.GetById(id));

        }
        [HttpPost]
        public ActionResult Edit(Product product)
        {
            unitOfWork.Products.Update(product);
            unitOfWork.Save();

            return RedirectToAction("Products", "Product");
        }
        [HttpGet]
        public ActionResult UploadProduct()
        {
            return View();

        }

        [HttpPost]
        public ActionResult UploadProduct(HttpPostedFileBase input, ProductViewModel product)
        {
            if (ModelState.IsValid)
            {
                if (product != null & input != null)
                {

                    Bitmap bitmap = new Bitmap(new Bitmap(input.InputStream), 350, 260);
                    bitmap.Save(Server.MapPath("~/Image/" + product.Name.Replace(" ","") + ".png"), ImageFormat.Jpeg);
                    string filepath = "~/Image/" + product.Name.Replace(" ", "") + ".png";
                    product.Absolutepath = filepath;
                    Mapper.Initialize(cfg => cfg.CreateMap<ProductViewModel,Product>());

                    Product prod = Mapper.Map<ProductViewModel, Product>(product);

                    unitOfWork.Products.Create(prod);
                    unitOfWork.Save();
                

                }
                return RedirectToAction("Index", "Home");
            }



            return View("UploadProduct");

        }

       

        public ActionResult FoundProductByName(int id)
        {
       
            Product product = unitOfWork.Products.GetById(id);
            return View(product);
        }
        public ActionResult Remove(int id)
        {
            unitOfWork.Products.Remove(id);
            unitOfWork.Save();
            return RedirectToAction("Products");

        }

    }
}