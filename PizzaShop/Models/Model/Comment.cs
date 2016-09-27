using System;
using System.ComponentModel.DataAnnotations;

namespace PizzaShop.Models.Model
{
    public class Comment
    {
        public int Id { get; set; }
        public string UserEmail { get; set; }
        public string Message { get; set; }
        public DateTime DateTime { get; set; }
    }
}