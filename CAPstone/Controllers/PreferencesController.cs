using CAPstone.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace CAPstone.Controllers
{
    public class PreferencesController : Controller
    {
        ApplicationDbContext context;
        public PreferencesController()
        {
            context = new ApplicationDbContext();
        }

        public ActionResult Index()
        {
            var preferences = new ParentsPreferenceSelectionEditorViewModel();
            foreach (var preference in context.Preferences)
            {
                var editorViewModel = new SelectedPreferencesEditorViewModel()
                {
                    Id = preference.Id,
                    preference = string.Format("{0}", preference.Preference),
                    Selected = true
                };
                preferences.Preferences.Add(editorViewModel);
            }
            return View(preferences);
        }


        [HttpPost]
        public ActionResult SubmitSelected(ParentsPreferenceSelectionEditorViewModel parentsPreferenceSelection)
        {
            var selectedIds = parentsPreferenceSelection.getSelectedIds();
            var selectedPreference = from p in context.Preferences
                                     where selectedIds.Contains(p.Id)
                                     select p;
            foreach (var preference in selectedPreference)
            {
                System.Diagnostics.Debug.WriteLine(
                    string.Format("{0}", preference.Preference));
            }
            return RedirectToAction("AddBudget", "Parent");
        }
    }
}