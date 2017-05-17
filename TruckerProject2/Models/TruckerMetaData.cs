using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace TruckerProject2.Models
{
    [MetadataType(typeof(Trucker.MetaData))]
    public partial class Trucker
    {
        sealed class MetaData
        { 
            [Key]
            public int TruckerID { get; set; }
            
            [Required(ErrorMessage = "First Name is required")]
            [Display(Name = "First Name")]
            public string FirstName { get; set; }

            [Required(ErrorMessage = "Last Name is required")]
            [Display(Name = "Last Name")]
            public string LastName { get; set; }

            [Required(ErrorMessage = "Address is required")]
            [Display(Name = "Address")]
            public string Address { get; set; }

            [Required(ErrorMessage = "City is required")]
            [Display(Name = "City")]
            public string City { get; set; }

            [Required(ErrorMessage = "State is required")]
            [Display(Name = "State")]
            public string State { get; set; }

            [Required(ErrorMessage = "Zip Code is required")]
            [Display(Name = "Zip Code")]
            public string Zip { get; set; }

            [Required(ErrorMessage = "License Number is required")]
            [Display(Name = "License Number")]
            public string LicenseNumber { get; set; }

            [Required(ErrorMessage = "Expiration Date is required")]
            [Display(Name = "Expiration Date")]
            [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}")]
            public DateTime ExpirationDate { get; set; }


            [Display(Name ="Class")]
            public ICollection<License> Licenses { get; set; }
        }
    }
}