using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CAPstone.Models
{
    public class Preferences
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "Choose Your Preference(s):")]
        public string Preference { get; set; }
        //public bool IsChecked { get; set; }
    }
    /*public class SelectedPreferences
    {
        public List<Preferences> Preferences { get; set; }
    }*/
}
   