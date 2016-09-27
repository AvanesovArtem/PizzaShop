using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PizzaShop.Models;
using PizzaShop.Models.Model;

namespace Shop.Models.Repository
{
    public class CartRepository
    {
        private ApplicationDbContext context;

        public CartRepository(ApplicationDbContext context)
        {
            this.context = context;
        }
        public IEnumerable<Cart> GetAll()
        {
            return context.Carts;
        }

        public Cart GetById(int id)
        {
            return context.Carts.Find(id);
          
        }
        public IEnumerable<Cart> GetUserOrders(string email)
        {
            return context.Carts.Where(x => x.EmailUser == email);
        }

        public bool Create(Cart item)
        {
            try
            {
                context.Carts.Add(item);
            }
            catch
            {
                return false;
            }
            return true;
        }

        public void Update(Cart id)
        {
            throw new NotImplementedException();
        }

        public void Remove(int id)
        {
            Cart cart = context.Carts.Find(id);
            if (cart != null)
                context.Carts.Remove(cart);
         
        }
    }
}