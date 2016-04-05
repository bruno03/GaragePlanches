using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace GaragePlanches.Models
{
    [Table("Voiture")]
    public class Car
    {
        public int CarID { get; set; }

        [Required]
        [Display(Name = "Marque")]
        [StringLength(50, MinimumLength = 2)]
        public string Brand { get; set; }

        [Display(Name = "Modèle")]
        [StringLength(50, MinimumLength = 2)]
        public string Model { get; set; }

        [Display(Name = "N° d'immatriculation")]
        [StringLength(20, MinimumLength = 2)]
        public string Immatrication { get; set; }

        [Display(Name = "Année")]
        [Range(1900, 2500)]
        public int Year { get; set; }


        public new string FullName
        {
            get
            {
                return Brand + " " + Model; 
            }
        }
        public int CustomerID { get; set; }
        public virtual Customer Customer { get; set; }
    }
}