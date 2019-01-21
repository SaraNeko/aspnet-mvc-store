using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Inlämmningsuppgift_ASP.NET_MVC.ViewModels
{
    public class ProductIndexViewModel
    {
        public ProductIndexViewModel()
        {
            Products = new List<ProductListViewModel>();
        }
        public class ProductListViewModel
        {
            public int id { get; set; }
            public string name { get; set; }
            public string description { get; set; }
            public int price { get; set; }
        }
        public List<ProductListViewModel> Products { get; set; }

        public string CurrentQuery { get; set; }
        public string CurrentSort { get; set; }
    }
}