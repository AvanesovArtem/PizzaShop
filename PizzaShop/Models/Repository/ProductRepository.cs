using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;
using PizzaShop.Models;
using PizzaShop.Models.Model;

namespace Shop.Models.Repository
{
    public class ProductRepository : IRepository<Product>
    {
        private ApplicationDbContext context;

        public ProductRepository(ApplicationDbContext Context)
        {
            context = Context;
        }
        public IEnumerable<Product> GetFirst8()
        {
            return context.Products.Take(8);
        }
        public IEnumerable<Product> GetAll()
        {
            return context.Products.Take(8);
        }
        public IEnumerable<Product> GetItemsPage(int page = 1)
        {
            var skip = page * 8;
            return context.Products.OrderBy(x=>x.Id).Skip(skip).Take(8);
        }
        public IList AutoComplete(string term)
        {

            IEnumerable<Product> products = FindByName(term);
            var projection = from product in products
                             select new
                             {
                                 id = product.Id,
                                 label = product.Name,
                                 value = product.Name
                             };
            return projection.ToList();
        }

        public Product GetById(int id)
        {
             return context.Products.Find(id);      
        }

        public IEnumerable<Product> FindByName(string name)
        {
            return context.Products.Where(x => x.Name.StartsWith(name));
        } 
        public void Create(Product item)
        {     
                context.Products.Add(item);
        }

        public void Update(Product item)
        {
            context.Entry(item).State = EntityState.Modified;
          
        }

        public void Remove(int id)
        {
            Product product = context.Products.Find(id);
            if (product != null)
            {
                context.Products.Remove(product);
       
            }
            
        }
    }
}