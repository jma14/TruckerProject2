using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TruckerProject2.Models;

namespace TruckerProject2.ViewModels
{
    public class EditViewModel
    {
        public Trucker Trucker { get; set; }
        public List<License> Licenses { get; set; }
        public List<State> States { get; set; }


        public EditViewModel(Trucker trucker, List<License> licenses, List<State> states)
        {
            Trucker = trucker;
            Licenses = licenses;
            States = states;
        }
    }
}