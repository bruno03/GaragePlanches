namespace GaragePlanches.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Validation : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Cars", "Brand", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.Cars", "Model", c => c.String(maxLength: 50));
            AlterColumn("dbo.Cars", "Immatrication", c => c.String(maxLength: 20));
            AlterColumn("dbo.Customers", "Firstname", c => c.String(maxLength: 50));
            AlterColumn("dbo.Customers", "Lastname", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.WorkOrders", "Price", c => c.Decimal(nullable: false, precision: 18, scale: 2));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.WorkOrders", "Price", c => c.Single(nullable: false));
            AlterColumn("dbo.Customers", "Lastname", c => c.String());
            AlterColumn("dbo.Customers", "Firstname", c => c.String());
            AlterColumn("dbo.Cars", "Immatrication", c => c.String());
            AlterColumn("dbo.Cars", "Model", c => c.String());
            AlterColumn("dbo.Cars", "Brand", c => c.String());
        }
    }
}
