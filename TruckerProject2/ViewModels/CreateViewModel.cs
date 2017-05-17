using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TruckerProject2.Models;

namespace TruckerProject2.ViewModels
{
    public class CreateViewModel
    {
        public Trucker Trucker { get; set; }
        public List<License> Licenses { get; set; }
        public List<State> States { get; set; }


        public CreateViewModel(List<License> licenses, List<State> states)
        {
            Trucker Trucker = new Trucker();
            Licenses = licenses;
            States = states;
        }
    }
}