using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Preferences.Models
{
    public class Preference
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "Choose Preferences")]
        public string Preferences { get; set; }
    }
}