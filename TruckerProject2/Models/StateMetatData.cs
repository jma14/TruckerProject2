using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TruckerProject2.Models
{
    [MetadataType(typeof(State.MetaData))]

    public partial class State
    {
        sealed class MetaData
        {       
            [Key]
            [Required(ErrorMessage = "State is required")]
            [Display(Name = "State")]
            public string StateID { get; set; }
        }
    }
}