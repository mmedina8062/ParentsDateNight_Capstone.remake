using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CAPstone.Models
{
    public class ParentsPreferenceSelectionEditorViewModel
    {
        public int ParentID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string StreetAddress { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public int ZipCode { get; set; }
        public double Budget { get; set; }
        public int Miles { get; set; }
        public List<SelectedPreferencesEditorViewModel> Preferences { get; set; }
        public ParentsPreferenceSelectionEditorViewModel()
        {
            this.Preferences = new List<SelectedPreferencesEditorViewModel>();
        }
        public IEnumerable<int> getSelectedIds()
        {
            return (from p in this.Preferences where p.Selected select p.Id).ToList();
        }
    }
}