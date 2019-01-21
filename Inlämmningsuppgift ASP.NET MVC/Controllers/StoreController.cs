using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Inlämmningsuppgift_ASP.NET_MVC.Controllers
{
    public class StoreController : Controller
    {
        // GET: Category
        public ActionResult Index(string sort)
        {
            var model = new ViewModels.CategoryIndexViewModel();
            var db = new Models.DBModel();

            model.Categories.AddRange(db.ProductCategories.Select(r => new ViewModels.CategoryIndexViewModel.CategoryListViewModel
            {
                id = r.id,
                name = r.name
               
            }));

            if (sort == "NameAsc")
                model.Categories = model.Categories.OrderBy(r => r.name).ToList();
            else if (sort == "NameDesc")
                model.Categories = model.Categories.OrderByDescending(r => r.name).ToList();

            model.CurrentSort = sort ?? "NameAsc";

            return View(model);
        }

        [HttpGet]
        public ActionResult Category(int id, string sort)
        {
            var model = new ViewModels.ProductIndexViewModel();
            var db = new Models.DBModel();

            model.Products.AddRange(db.Products.Where(p => p.categoryId == id).Select(r => new ViewModels.ProductIndexViewModel.ProductListViewModel
            {
                id = r.id,
                name = r.name,
                description = r.description,
                price = r.price
            }));

            if (sort == "NameAsc")
                model.Products = model.Products.OrderBy(r => r.name).ToList();
            else if (sort == "NameDesc")
                model.Products = model.Products.OrderByDescending(r => r.name).ToList();

            if (sort == "PriceAsc")
                model.Products = model.Products.OrderBy(r => r.price).ToList();
            else if (sort == "PriceDesc")
                model.Products = model.Products.OrderByDescending(r => r.price).ToList();

            model.CurrentSort = sort ?? "NameAsc";

            return View(model);
        }

        [HttpGet]
        public ActionResult Search(string query, string sort)
        {
            var model = new ViewModels.ProductIndexViewModel();
            var db = new Models.DBModel();

            model.Products.AddRange(db.Products.Where(p => p.name.Contains(query) || p.description.Contains(query)).Select(r => new ViewModels.ProductIndexViewModel.ProductListViewModel
            {
                id = r.id,
                name = r.name,
                description = r.description,
                price = r.price
            }));

            model.CurrentQuery = query;

            if (sort == "NameAsc")
                model.Products = model.Products.OrderBy(r => r.name).ToList();
            else if (sort == "NameDesc")
                model.Products = model.Products.OrderByDescending(r => r.name).ToList();

            if (sort == "PriceAsc")
                model.Products = model.Products.OrderBy(r => r.price).ToList();
            else if (sort == "PriceDesc")
                model.Products = model.Products.OrderByDescending(r => r.price).ToList();

            model.CurrentSort = sort ?? "NameAsc";

            return View(model);
        }

        [HttpGet]
        [Authorize(Roles = "Admin, Product Manager")]
        public ActionResult CreateCategory()
        {
            var model = new ViewModels.CategoryCreateViewModel();
            return View(model);
        }

        [HttpPost]
        [Authorize(Roles = "Admin, Product Manager")]
        public ActionResult CreateCategory(ViewModels.CategoryCreateViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            using (var db = new Models.DBModel())
            {
                var category = new Models.ProductCategory
                {
                    id = model.id,
                    name = model.name
                };
                db.ProductCategories.Add(category);
                db.SaveChanges();
            }
            return RedirectToAction("Index");
        }

        [HttpGet]
        [Authorize(Roles = "Admin, Product Manager")]
        public ActionResult CreateProduct()
        {
            var model = new ViewModels.ProductCreateViewModel();
            return View(model);
        }

        [HttpPost]
        [Authorize(Roles = "Admin, Product Manager")]
        public ActionResult CreateProduct(ViewModels.ProductCreateViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            using (var db = new Models.DBModel())
            {
                var product = new Models.Product
                {
                    id = model.id,
                    name = model.name,
                    description = model.description,
                    price = model.price,
                    categoryId = model.categoryId
                };
                db.Products.Add(product);
                db.SaveChanges();
            }
            return RedirectToAction("Index");
        }

        public ActionResult Product(int id)
        {
            using (var db = new Models.DBModel())
            {
                var product = db.Products.FirstOrDefault(r => r.id == id);
                var model = new ViewModels.ProductViewViewModel
                {
                    name = product.name,
                    description = product.description,
                    price = product.price
                };
                return View(model);
            }
        }

        [HttpGet]
        [Authorize(Roles = "Admin, Product Manager")]
        public ActionResult Edit(int id)
        {
            using (var db = new Models.DBModel())
            {
                var product = db.Products.FirstOrDefault(p => p.id == id);
                var model = new ViewModels.ProductEditViewModel
                {
                    name = product.name,
                    description = product.description,
                    price = product.price,
                    id = product.id,
                    categoryId = product.categoryId
                };
                return View(model);
            }
        }

        [HttpPost]
        [Authorize(Roles = "Admin, Product Manager")]
        public ActionResult Edit(ViewModels.ProductEditViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            using (var db = new Models.DBModel())
            {
                var product = db.Products.FirstOrDefault(r => r.id == model.id);
                product.name = model.name;
                product.description = model.description;
                product.price = model.price;
                product.id = model.id;
                product.categoryId = model.categoryId;
                db.SaveChanges();
            }
            return RedirectToAction("Index");
        }

        [HttpGet]
        [Authorize(Roles = "Admin, Product Manager")]
        public ActionResult EditCategory(int id)
        {
            using (var db = new Models.DBModel())
            {
                var category = db.ProductCategories.FirstOrDefault(p => p.id == id);
                var model = new ViewModels.CategoryEditViewModel
                {
                    name = category.name,
                    id = category.id
                };
                return View(model);
            }
        }

        [HttpPost]
        [Authorize(Roles = "Admin, Product Manager")]
        public ActionResult EditCategory(ViewModels.CategoryEditViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            using (var db = new Models.DBModel())
            {
                var category = db.ProductCategories.FirstOrDefault(r => r.id == model.id);
                category.name = model.name;
                category.id = model.id;
                db.SaveChanges();
            }
            return RedirectToAction("Index");
        }
        
    }
}