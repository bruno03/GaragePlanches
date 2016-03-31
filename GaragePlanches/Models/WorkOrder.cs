using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace GaragePlanches.Models
{
    [Table("OT")]
    public class WorkOrder
    {
        public int WorkOrderID { get; set; }

        [Display(Name = "Prix")]
        [DataType(DataType.Currency)]
        public decimal Price { get; set; }

        [Display(Name = "Kilométrage")]
        [Required]
        public int Kilometers { get; set; }

        public int CustomerID { get; set; }
        public virtual Customer Customer { get; set; }

        public int CarID { get; set; }
        public virtual Car Car { get; set; }
    }
}