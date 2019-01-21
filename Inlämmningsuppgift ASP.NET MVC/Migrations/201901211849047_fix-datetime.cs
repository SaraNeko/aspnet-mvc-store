namespace Inlämmningsuppgift_ASP.NET_MVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class fixdatetime : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.AspNetUsers", "LockoutEndDateUtc", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.AspNetUsers", "LockoutEndDateUtc", c => c.DateTime(nullable: false));
        }
    }
}
