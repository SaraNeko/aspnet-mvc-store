using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Inlämmningsuppgift_ASP.NET_MVC.ViewModels
{
    public class CategoryIndexViewModel
    {
        public CategoryIndexViewModel()
        {
            Categories = new List<CategoryListViewModel>();
        }
        public class CategoryListViewModel
        {
            public int id { get; set; }
            public string name { get; set; }
        }
        public List<CategoryListViewModel> Categories { get; set; }

        public string CurrentSort { get; set; }
    }
}