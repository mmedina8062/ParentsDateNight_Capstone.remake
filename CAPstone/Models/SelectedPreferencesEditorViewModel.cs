﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CAPstone.Models
{
    public class SelectedPreferencesEditorViewModel
    {
        public int Id { get; set; }
        public string preference { get; set; }
        public bool Selected { get; set; }
    }
}