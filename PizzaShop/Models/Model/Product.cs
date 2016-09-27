using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace PizzaShop.Models.Model
{
    public class Product
    {
        public Product()
        {
            Cart = new HashSet<Cart>();
        }
        public int Id { get; set; }
        [MaxLength(50)]
        public string Name { get; set; }

        public string Description { get; set; }
      
        public string Absolutepath { get; set; }
        public decimal Price { get; set; }
        public virtual ICollection<Cart> Cart { get; set; }

    }
}