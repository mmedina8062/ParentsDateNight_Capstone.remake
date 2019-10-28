using Preferences.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Preferences.Controllers
{
    public class PreferencesController : ApiController
    {
        private ApplicationDbContext context;

        public PreferencesController()
        {
            context = new ApplicationDbContext();
        }
        // GET: api/Preference
        public IEnumerable<Preference> Get()
        {
            return context.Preferences.ToList();
        }

        // GET: api/Preference/5
        public Preference GetPreference(int id)
        {
            var preferences = context.Preferences.SingleOrDefault(p => p.Id == id);

            if (preferences == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);
            return preferences;
        }

        // POST: api/Preference
        public Preference CreatePreference([FromBody]Preference preference)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            context.Preferences.Add(preference);
            context.SaveChanges();
            return preference;
        }

        // PUT: api/Preference/5
        public Preference UpdatePreferences(int id, [FromBody]Preference preferences)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            var preference = context.Preferences.SingleOrDefault(p => p.Id == id);

            if (preference == null)
                if (!ModelState.IsValid)
                    throw new HttpResponseException(HttpStatusCode.NotFound);

            preference.Preferences = preference.Preferences;

            context.SaveChanges();
            return preference;
        }

        // DELETE: api/Preference/5
        public void Delete(int id)
        {
            var preference = context.Preferences.SingleOrDefault(p => p.Id == id);

            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            context.Preferences.Remove(preference);
            context.SaveChanges();
        }
    }
}
