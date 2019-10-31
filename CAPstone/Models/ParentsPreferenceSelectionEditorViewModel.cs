using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CAPstone.Models
{
    public class ParentsPreferenceSelectionEditorViewModel
    {
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