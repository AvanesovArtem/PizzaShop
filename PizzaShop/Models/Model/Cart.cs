using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web.UI.WebControls.WebParts;
using PizzaShop.Migrations;

namespace PizzaShop.Models.Model
{
    public class Cart
    {
       
        public int Id { get; set; }
        public int Quantity { get; set; }
        public DateTime PurchaseDate { get; set; }

        public string EmailUser { get; set; }
        public int ProductId { get; set; }
        public virtual Product Product { get; set; }
  
       
    }
}