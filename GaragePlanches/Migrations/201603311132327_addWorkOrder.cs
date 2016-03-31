namespace GaragePlanches.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addWorkOrder : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.WorkOrders",
                c => new
                    {
                        WorkOrderID = c.Int(nullable: false, identity: true),
                        Price = c.Single(nullable: false),
                        CustomerID = c.Int(nullable: false),
                        CarID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.WorkOrderID)
                .ForeignKey("dbo.Cars", t => t.CarID, cascadeDelete: false)
                .ForeignKey("dbo.Customers", t => t.CustomerID, cascadeDelete: false)
                .Index(t => t.CustomerID)
                .Index(t => t.CarID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.WorkOrders", "CustomerID", "dbo.Customers");
            DropForeignKey("dbo.WorkOrders", "CarID", "dbo.Cars");
            DropIndex("dbo.WorkOrders", new[] { "CarID" });
            DropIndex("dbo.WorkOrders", new[] { "CustomerID" });
            DropTable("dbo.WorkOrders");
        }
    }
}
