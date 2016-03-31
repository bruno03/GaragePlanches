namespace GaragePlanches.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeDisplayNameTable : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.Cars", newName: "Voiture");
            RenameTable(name: "dbo.Customers", newName: "Client");
            RenameTable(name: "dbo.WorkOrders", newName: "OT");
        }
        
        public override void Down()
        {
            RenameTable(name: "dbo.OT", newName: "WorkOrders");
            RenameTable(name: "dbo.Client", newName: "Customers");
            RenameTable(name: "dbo.Voiture", newName: "Cars");
        }
    }
}
