using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Inlämmningsuppgift_ASP.NET_MVC.Models
{
    public class ProductCategory
    {
        public int id { get; set; }
        public string name { get; set; }

        public virtual ICollection<Product> Products { get; set; }
    }
}