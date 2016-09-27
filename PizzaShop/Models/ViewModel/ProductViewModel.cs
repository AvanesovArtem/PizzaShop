using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PizzaShop.Models.ViewModel
{
    public class ProductViewModel
    {
        [Required(ErrorMessage = "Вы не ввели описание")]
        public string Name { get; set; }
        [MaxLength(150,ErrorMessage = "Описание должно быть меньше 150 символов")]
        [Required(ErrorMessage = "Вы не ввели описание")]
        public string Description { get; set; }
        [Required(ErrorMessage = "Вы не ввели цену")]
        public decimal Price { get; set; }
        [ScaffoldColumn(false)]
        public string Absolutepath { get; set; }
    }
}