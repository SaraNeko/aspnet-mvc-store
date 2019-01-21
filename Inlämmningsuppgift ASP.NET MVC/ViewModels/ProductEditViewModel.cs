using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Inlämmningsuppgift_ASP.NET_MVC.ViewModels
{
    public class ProductEditViewModel
    {
        public int id { get; set; }

        [Required]
        public string name { get; set; }

        [Required]
        public int categoryId { get; set; }

        public string description { get; set; }
        public int price { get; set; }
    }
}