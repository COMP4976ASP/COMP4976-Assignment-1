namespace ZenithWebSite.Migrations.ZenithMigrations
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using ZenithDataLib.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<ZenithDataLib.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            MigrationsDirectory = @"Migrations\ZenithMigrations";
        }

        protected override void Seed(ApplicationDbContext context)
        {
            context.Activities.AddOrUpdate(a => a.ActivityDescription, GetActivities());
            context.SaveChanges();

            context.Events.AddOrUpdate(e => e.EventFrom, GetEvents(context));
            context.SaveChanges();
        }

        private Activity[] GetActivities()
        {
            var activities = new List<Activity>
            {
                new Activity
                {
                    ActivityDescription = "Senior's Golf Tournament",
                    CreationDate = DateTime.Now
                },
                new Activity
                {
                    ActivityDescription = "Leadership General Assembly Meeting",
                    CreationDate = DateTime.Now
                }
            };

            return activities.ToArray();
        }

        private Event[] GetEvents(ApplicationDbContext context)
        {
            var events = new List<Event>
            {
                new Event
                {
                    EventFrom = new DateTime(2017, 2, 7, 8, 30, 0),
                    EventTo = new DateTime(2017, 2, 7, 10, 30, 0),
                    Username = "jason",
                    Activity = context.Activities.FirstOrDefault(a => a.ActivityDescription == "Senior's Golf Tournament"),
                    CreationDate = DateTime.Now,
                    IsActive = false
                },
                new Event
                {
                    EventFrom = new DateTime(2017, 2, 7, 8+12, 30, 0),
                    EventTo = new DateTime(2017, 2, 7, 11+12, 30, 0),
                    Username = "jason",
                    Activity = context.Activities.FirstOrDefault(a => a.ActivityDescription == "Leadership General Assembly Meeting"),
                    CreationDate = DateTime.Now,
                    IsActive = true
                }
            };

            return events.ToArray();
        }
    }
}
