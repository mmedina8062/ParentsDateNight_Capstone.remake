﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace CAPstone.Models
{
    public class Parent
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Display(Name = "Street Address")]
        public string StreetAddress { get; set; }
        public string City { get; set; }
        public string State { get; set; }

        [Display(Name = "Zip Code")]
        public int ZipCode { get; set; }

        [ForeignKey("ApplicationUser")]
        public string ApplicationId { get; set; }
        public ApplicationUser ApplicationUser { get; set; }
        public double Budget { get; set; }
        public int Miles { get; set; }
     
        /*[ForeignKey("Sitters")]
        public ICollection<Sitter> Sitters { get; set; }*/

        /*[ForeignKey("Date night Ideas")]
        public IList<Preferences> Preferences { get; set; }*/
    }
}