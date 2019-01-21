using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Inlämmningsuppgift_ASP.NET_MVC.ViewModels
{
    public class CategoryCreateViewModel
    {
        public int id { get; set; }

        [Required]
        public string name { get; set; }

    }
}