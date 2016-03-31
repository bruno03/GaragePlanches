using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace GaragePlanches.Models
{
    [Table("Client")]
    public class Customer
    {

        public int CustomerID { get; set; }

        [Display(Name = "Prénom")]
        [StringLength(50, MinimumLength = 2)]
        public string Firstname { get; set; }

        [Required]
        [Display(Name = "Nom")]
        [StringLength(50, MinimumLength = 2)]
        public string Lastname { get; set; }

        [Display(Name = "Adresse")]
        public string Address { get; set; }

        public virtual List<Car>Cars { get; set; }

    }
}