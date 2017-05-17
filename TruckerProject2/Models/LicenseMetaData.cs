using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TruckerProject2.Models
{
    [MetadataType(typeof(License.MetaData))]

    public partial class License
    {
        sealed class MetaData
        {       
            [Key]
            [Required(ErrorMessage = "License Type is required")]
            [Display(Name = "Class")]
            public string LicenseType { get; set; }
        }
    }
}