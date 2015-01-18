using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyShop_MVC.Models
{
    public class ShoppingCart
    {
        public int ID { get; set; }
        public int Quantity { get; set; }
        public int ProductID { get; set; }
    }
}