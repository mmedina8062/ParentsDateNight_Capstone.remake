using CAPstone.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Spatial;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
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
        public async Task<List<GoogleMapsJson.Result>> PlacesApiSearch(string type, string LatLong)
        {
            var http = new HttpClient();
            var url = String.Format("https://maps.googleapis.com/maps/api/place/nearbysearch/json?location={0}&radius=2000&type={1}&key=APIKey", LatLong, type, APIKey.googleAPI);
            var response = await http.GetAsync(url);
            var result = await response.Content.ReadAsStringAsync();
            var jsonData = JsonConvert.DeserializeObject<GoogleMapsJson.Rootobject>(result);
            var resultsList = new List<GoogleMapsJson.Result>();

            for (int i = 0; i < jsonData.results.Count(); i++)
            {
                resultsList.Add(jsonData.results[i]);
            }

            return resultsList;
        }

        public async Task<string> FindLocationLatLongString(string location)
        {
            var http = new HttpClient();
            var url = String.Format("https://maps.googleapis.com/maps/api/geocode/json?address={0}&key=APIKey", location, APIKey.googleAPI);
            var response = await http.GetAsync(url);
            var result = await response.Content.ReadAsStringAsync();
            var jsonData = JsonConvert.DeserializeObject<GoogleMapsJson.Rootobject>(result);
            var latLong = jsonData.results[0].geometry.location.lat.ToString() + "," + jsonData.results[0].geometry.location.lng.ToString();

            return latLong;
        }

        /*public ActionResult GetNearByLocations(string Currentlat, string Currentlng)
        {
                var currentLocation = DbGeography.FromText("POINT( " + Currentlng + " " + Currentlat + " )");

                //var currentLocation = DbGeography.FromText("POINT( 78.3845534 17.4343666 )");

                var places = (from p in context.Preferences
                              orderby p.GeoLocation.Distance(currentLocation)
                              select p).Take(4).Select(x => new GoogleMapsJson.Geometry() { location = x.SchoolName, lat = x.GeoLocation.Latitude, lng = x.GeoLocation.Longitude, Distance = x.GeoLocation.Distance(currentLocation) });
                var nearschools = places.ToList();

                return Json(nearschools, JsonRequestBehavior.AllowGet);
        
        }*/
    }
}