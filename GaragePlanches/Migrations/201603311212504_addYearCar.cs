namespace GaragePlanches.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addYearCar : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Cars", "Year", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Cars", "Year");
        }
    }
}
