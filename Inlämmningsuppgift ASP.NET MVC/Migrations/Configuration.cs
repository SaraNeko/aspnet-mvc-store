namespace Inlämmningsuppgift_ASP.NET_MVC.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Inlämmningsuppgift_ASP.NET_MVC.Models.DBModel>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "Inlämmningsuppgift_ASP.NET_MVC.Models.DBModel";
        }

        protected override void Seed(Inlämmningsuppgift_ASP.NET_MVC.Models.DBModel context)
        {
            context.Products.AddOrUpdate(c => c.id,
                new Models.Product { id = 1, name = "Bottle of Oil", description = "For cooking", price = 8, categoryId = 1 },
                new Models.Product { id = 2, name = "Warm Socks", description = "100% Cotton", price = 40, categoryId = 2 }
                );

            context.ProductCategories.AddOrUpdate(c => c.id,
                new Models.ProductCategory { id = 1, name = "Food" },
                new Models.ProductCategory { id = 2, name = "Clothes" }
                );

            context.AspNetUsers.AddOrUpdate(c => c.Id,
                new Models.AspNetUser
                {
                    Id = "owo",
                    Email = "owo@gmail.com",
                    EmailConfirmed = true,
                    PasswordHash = "owo",
                    SecurityStamp = "OwO",
                    PhoneNumber = "030",
                    PhoneNumberConfirmed = true,
                    TwoFactorEnabled = true,
                    LockoutEndDateUtc = DateTime.Now,
                    LockoutEnabled = false,
                    AccessFailedCount = 0,
                    UserName = "owo"
                });
        }
    }
}
