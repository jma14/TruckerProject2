using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TruckerProject2.Models;

namespace TruckerProject2.ViewModels
{
    public class IndexViewModel
    {
        public List<Trucker> Truckers { get; set; }
        public List<License> Licenses { get; set; }
        public string SearchCriteria { get; set; }


        public IndexViewModel(List<Trucker> truckers, List<License> licenses)
        {
            Truckers = truckers;
            Licenses = licenses;
        }

        public IndexViewModel(List<Trucker> truckers, List<License> licenses, string searchCriteria)
        {
            Truckers = truckers;
            Licenses = licenses;
            SearchCriteria = searchCriteria;
        }
    }
}