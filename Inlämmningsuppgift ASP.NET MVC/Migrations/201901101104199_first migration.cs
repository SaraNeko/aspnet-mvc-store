namespace Inlämmningsuppgift_ASP.NET_MVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class firstmigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ProductCategories",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        namn = c.String(),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        namn = c.String(),
                        description = c.String(),
                        price = c.Int(nullable: false),
                        categoryId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.ProductCategories", t => t.categoryId, cascadeDelete: true)
                .Index(t => t.categoryId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Products", "categoryId", "dbo.ProductCategories");
            DropIndex("dbo.Products", new[] { "categoryId" });
            DropTable("dbo.Products");
            DropTable("dbo.ProductCategories");
        }
    }
}
