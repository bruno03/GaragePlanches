namespace GaragePlanches.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addLastnameCustomer : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Cars",
                c => new
                    {
                        CarID = c.Int(nullable: false, identity: true),
                        Brand = c.String(),
                        CustomerID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.CarID)
                .ForeignKey("dbo.Customers", t => t.CustomerID, cascadeDelete: true)
                .Index(t => t.CustomerID);
            
            CreateTable(
                "dbo.Customers",
                c => new
                    {
                        CustomerID = c.Int(nullable: false, identity: true),
                        Firstname = c.String(),
                        Lastname = c.String(),
                    })
                .PrimaryKey(t => t.CustomerID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Cars", "CustomerID", "dbo.Customers");
            DropIndex("dbo.Cars", new[] { "CustomerID" });
            DropTable("dbo.Customers");
            DropTable("dbo.Cars");
        }
    }
}
