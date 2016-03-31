using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace GaragePlanches.Models
{
    public class GarageContext :DbContext
    {
        public DbSet<Customer>Customers { get; set; }
        public DbSet<Car> Car { get; set; }
        public DbSet<WorkOrder> WorkOrder { get; set; }

    }
}