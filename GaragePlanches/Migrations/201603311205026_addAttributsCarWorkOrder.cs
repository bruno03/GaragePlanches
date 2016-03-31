namespace GaragePlanches.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addAttributsCarWorkOrder : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Cars", "Model", c => c.String());
            AddColumn("dbo.Cars", "Immatrication", c => c.String());
            AddColumn("dbo.Customers", "Address", c => c.String());
            AddColumn("dbo.WorkOrders", "Kilometers", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.WorkOrders", "Kilometers");
            DropColumn("dbo.Customers", "Address");
            DropColumn("dbo.Cars", "Immatrication");
            DropColumn("dbo.Cars", "Model");
        }
    }
}
