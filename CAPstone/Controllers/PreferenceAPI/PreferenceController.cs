using CAPstone.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace CAPstone.Controllers.PreferenceAPI
{
    public class PreferenceController : ApiController
    {
        private ApplicationDbContext context;

        public PreferenceController()
        {
            context = new ApplicationDbContext();
        }
        // GET: api/Preference
        public IEnumerable<Preferences> Get()
        {
            return context.Preferences.ToList();
        }

        // GET: api/Preference/5
        public Preferences GetPreferences(int id)
        {
            var preferences = context.Preferences.SingleOrDefault(p => p.Id == id);

            if (preferences == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);
            return preferences;
        }

        // POST: api/Preference
        public Preferences CreatePreferences([FromBody]Preferences preferences)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            context.Preferences.Add(preferences);
            context.SaveChanges();
            return preferences;
        }

        // PUT: api/Preference/5
        public Preferences UpdatePreferences(int id, [FromBody]Preferences preferences)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            var preference = context.Preferences.SingleOrDefault(p => p.Id == id);

            if (preference == null)
                if (!ModelState.IsValid)
                    throw new HttpResponseException(HttpStatusCode.NotFound);

            preference.Preference = preference.Preference;

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
