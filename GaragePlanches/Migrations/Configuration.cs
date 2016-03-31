namespace GaragePlanches.Migrations
{
    using Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<GaragePlanches.Models.GarageContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(GaragePlanches.Models.GarageContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //

            /*
            context.Customers.AddOrUpdate(
                c => c.CustomerID,
                new Customer { CustomerID = 1, Firstname = "Bruno", Lastname = "Salemi", Address = "Dents-du-Midi 92A" },
                new Customer { CustomerID = 2, Firstname = "Thomas", Lastname = "Salemi", Address = "Charmette 52" },
                new Customer { CustomerID = 3, Firstname = "Giancarlo", Lastname = "Salemi", Address = "Industrie 3" },
                new Customer { CustomerID = 4, Firstname = "Raymonde", Lastname = "Salemi", Address = "Charmette 52" },
                new Customer { CustomerID = 5, Firstname = "Diana", Lastname = "Grilo", Address = "Dents-du-Midi 92A" },
                new Customer { CustomerID = 6, Firstname = "Mario", Lastname = "Alibrando", Address = "Charmette 52" }
                );

            
            context.Car.AddOrUpdate(
                c => c.CarID,
                new Car { Brand = "Honda", Model = "Civic type R", Year = 2003, Immatrication = "VS21097", CustomerID = 1},
                new Car { Brand = "Honda", Model = "Accord", Year = 2006, Immatrication = "VS239482", CustomerID = 2 },
                new Car { Brand = "Subaru", Model = "Impreza", Year = 2003, Immatrication = "VD 25 U", CustomerID = 3 },
                new Car { Brand = "Peugeot", Model = "206", Year = 2010, Immatrication = "VS294838", CustomerID = 3 },
                new Car { Brand = "Honda", Model = "Jazz", Year = 2003, Immatrication = "BS248482", CustomerID = 4 },
                new Car { Brand = "Mini", Model = "Cooper", Year = 2010, Immatrication = "VS93384", CustomerID = 5 },
                new Car { Brand = "VW", Model = "Polo", Year = 2014, Immatrication = "BS38439", CustomerID = 6 }
                );
*/
    
        }
    }
}
