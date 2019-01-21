using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;

namespace Inlämmningsuppgift_ASP.NET_MVC.Models
{
    public class Product
    {
        public int id { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public int price { get; set; }

        [ForeignKey("Category")]
        public int categoryId { get; set; }
        public virtual ProductCategory Category { get; set; }
    }
}