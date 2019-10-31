namespace CAPstone.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<CAPstone.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(CAPstone.Models.ApplicationDbContext context)
        {
            //  This method will be called after migrating to the latest version.
            /*context.Preferences.AddOrUpdate(
               new Models.Preferences { Preference = "Pinics" },
               new Models.Preferences { Preference = "Walks" },
               new Models.Preferences { Preference = "Restaurants" },
               new Models.Preferences { Preference = "Movies" },
               new Models.Preferences { Preference = "Staying in" },
               new Models.Preferences { Preference = "Horse Carriages or Horse Back Riding" },
               new Models.Preferences { Preference = "Aracde" },
               new Models.Preferences { Preference = "Bars" },
               new Models.Preferences { Preference = "Bowling" },
               new Models.Preferences { Preference = "Art" },
               new Models.Preferences { Preference = "Cooking" },
               new Models.Preferences { Preference = "Mini Golf" },
               new Models.Preferences { Preference = "Events (Concerts, Comedy Shows, etc)" },
               new Models.Preferences { Preference = "Get Away (Sybaris, Spas, etc)" },
               new Models.Preferences { Preference = "Boat Cruise" },
               new Models.Preferences { Preference = "Amusement Parks/Carnivals/Festivals" });*/
               /*new Models.Preferences { Preference = "Have a Budget? Let us know : " },
               new Models.Preferences { Preference = "Please let us know you prefer distance for traveling: " }); */

        }
    }
}
