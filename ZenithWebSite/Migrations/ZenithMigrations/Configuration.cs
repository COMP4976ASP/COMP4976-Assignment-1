namespace ZenithWebSite.Migrations.ZenithMigrations
{
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
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


            // Create an ADMIN role
            if (!context.Roles.Any(r => r.Name == "Admin"))
            {
                var store = new RoleStore<IdentityRole>(context);
                var manager = new RoleManager<IdentityRole>(store);
                var role = new IdentityRole { Name = "Admin" };

                manager.Create(role);
            }

            // Create a MEMBER role
            if (!context.Roles.Any(r => r.Name == "Member"))
            {
                var store = new RoleStore<IdentityRole>(context);
                var manager = new RoleManager<IdentityRole>(store);
                var role = new IdentityRole { Name = "Member" };

                manager.Create(role);
            }


            // Create a dummy user under ADMIN role
            if (!context.Users.Any(u => u.UserName == "a"))
            {
                var store = new UserStore<ApplicationUser>(context);
                var manager = new UserManager<ApplicationUser>(store);
                var user = new ApplicationUser { UserName = "a", Email = "a@a.a" };

                manager.Create(user, "P@$$w0rd");
                manager.AddToRole(user.Id, "Admin");
            }

            // Create a dummy user under MEMBER role
            if (!context.Users.Any(u => u.UserName == "m"))
            {
                var store = new UserStore<ApplicationUser>(context);
                var manager = new UserManager<ApplicationUser>(store);
                var user = new ApplicationUser { UserName = "m", Email = "m@m.m" };

                manager.Create(user, "P@$$w0rd");
                manager.AddToRole(user.Id, "Member");
            }
        }

        private Activity[] GetActivities()
        {
            var activities = new List<Activity>
            {
                new Activity
                {
                    ActivityDescription = "Breakfast Club",
                    CreationDate = new DateTime(2017, 2, 10, 9, 00, 0)
                },
                new Activity
                {
                    ActivityDescription = "Lunch Break",
                    CreationDate = new DateTime(2017, 2, 10, 9, 00, 0)
                },
                // Day 1
                new Activity
                {
                    ActivityDescription = "Watercolours Painting",
                    CreationDate = new DateTime(2017, 2, 10, 9, 00, 0)
                },
                new Activity
                {
                    ActivityDescription = "Knitting & Crochet",
                    CreationDate = new DateTime(2017, 2, 10, 9, 00, 0)
                },new Activity
                {
                    ActivityDescription = "Badminton",
                    CreationDate = new DateTime(2017, 2, 10, 9, 00, 0)
                },
                new Activity
                {
                    ActivityDescription = "Dance",
                    CreationDate = new DateTime(2017, 2, 10, 9, 00, 0)
                },new Activity
                {
                    ActivityDescription = "Floor Curling",
                    CreationDate = new DateTime(2017, 2, 10, 9, 00, 0)
                },
                //Day 2
                new Activity
                {
                    ActivityDescription = "Nordic Pole Walking",
                    CreationDate = new DateTime(2017, 2, 10, 9, 00, 0)
                },new Activity
                {
                    ActivityDescription = "- Blood Pressure Screening",
                    CreationDate = new DateTime(2017, 2, 10, 9, 00, 0)
                },
                new Activity
                {
                    ActivityDescription = "Senior Social and Fix-It Club Meeting",
                    CreationDate = new DateTime(2017, 2, 10, 9, 00, 0)
                },new Activity
                {
                    ActivityDescription = "55 Plus Travel Club Meeting",
                    CreationDate = new DateTime(2017, 2, 10, 9, 00, 0)
                },
                new Activity
                {
                    ActivityDescription = "VGH Hospital Tour",
                    CreationDate = new DateTime(2017, 2, 10, 9, 00, 0)
                },
                //Day 3
                new Activity
                {
                    ActivityDescription = "Needle Arts Guild Event",
                    CreationDate = new DateTime(2017, 2, 10, 9, 00, 0)
                },
                new Activity
                {
                    ActivityDescription = "Retirement Planning",
                    CreationDate = new DateTime(2017, 2, 10, 9, 00, 0)
                },
                new Activity
                {
                    ActivityDescription = "Fun Active Babes Snowshoeing",
                    CreationDate = new DateTime(2017, 2, 10, 9, 00, 0)
                },
                new Activity
                {
                    ActivityDescription = "Wit Knits",
                    CreationDate = new DateTime(2017, 2, 10, 9, 00, 0)
                },
                new Activity
                {
                    ActivityDescription = "Snowshoe 55 Club",
                    CreationDate = new DateTime(2017, 2, 10, 9, 00, 0)
                },
                //Day 4
                new Activity
                {
                    ActivityDescription = "Retirement Explorers",
                    CreationDate = new DateTime(2017, 2, 10, 9, 00, 0)
                },
                new Activity
                {
                    ActivityDescription = "Get Cooking Greek Style Workshops",
                    CreationDate = new DateTime(2017, 2, 10, 9, 00, 0)
                },
                new Activity
                {
                    ActivityDescription = "Oil & Acrylic Painting",
                    CreationDate = new DateTime(2017, 2, 10, 9, 00, 0)
                },
                new Activity
                {
                    ActivityDescription = "Badminton",
                    CreationDate = new DateTime(2017, 2, 10, 9, 00, 0)
                },
                new Activity
                {
                    ActivityDescription = "Billiards",
                    CreationDate = new DateTime(2017, 2, 10, 9, 00, 0)
                },
                // Day 5
                new Activity
                {
                    ActivityDescription = "Pottery",
                    CreationDate = new DateTime(2017, 2, 10, 9, 00, 0)
                },
                new Activity
                {
                    ActivityDescription = "Computer Club",
                    CreationDate = new DateTime(2017, 2, 10, 9, 00, 0)
                },
                new Activity
                {
                    ActivityDescription = "Ballroom Dance ",
                    CreationDate = new DateTime(2017, 2, 10, 9, 00, 0)
                },
                new Activity
                {
                    ActivityDescription = "Book Club",
                    CreationDate = new DateTime(2017, 2, 10, 9, 00, 0)
                },
                new Activity
                {
                    ActivityDescription = "Pickle Ball",
                    CreationDate = new DateTime(2017, 2, 10, 9, 00, 0)
                },
                // Day 6
                new Activity
                {
                    ActivityDescription = "Table Tennis",
                    CreationDate = new DateTime(2017, 2, 10, 9, 00, 0)
                },
                new Activity
                {
                    ActivityDescription = "Carpet Bowling",
                    CreationDate = new DateTime(2017, 2, 10, 9, 00, 0)
                },
                new Activity
                {
                    ActivityDescription = "Bingo",
                    CreationDate = new DateTime(2017, 2, 10, 9, 00, 0)
                },
                new Activity
                {
                    ActivityDescription = "P.U.R.L.S (Knitting)",
                    CreationDate = new DateTime(2017, 2, 10, 9, 00, 0)
                },
                new Activity
                {
                    ActivityDescription = "Sky Walkers",
                    CreationDate = new DateTime(2017, 2, 10, 9, 00, 0)
                },
                // Day 7
                new Activity
                {
                    ActivityDescription = "Creative Writing",
                    CreationDate = new DateTime(2017, 2, 10, 9, 00, 0)
                },
                new Activity
                {
                    ActivityDescription = "Seniors’ Lounge",
                    CreationDate = new DateTime(2017, 2, 10, 9, 00, 0)
                },
                new Activity
                {
                    ActivityDescription = "Woodcarvers",
                    CreationDate = new DateTime(2017, 2, 10, 9, 00, 0)
                },
                new Activity
                {
                    ActivityDescription = "Table Tennis",
                    CreationDate = new DateTime(2017, 2, 10, 9, 00, 0)
                },
                new Activity
                {
                    ActivityDescription = "Stamp Club",
                    CreationDate = new DateTime(2017, 2, 10, 9, 00, 0)
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
                    EventFrom = new DateTime(2017, 2, 12, 8, 30, 0),
                    EventTo = new DateTime(2017, 2, 12, 9, 30, 0),
                    Username = "jason",
                    Activity = context.Activities.FirstOrDefault(a => a.ActivityDescription == "Breakfast Club"),
                    CreationDate = new DateTime(2017, 2, 10, 9, 00, 0),
                    IsActive = false
                },
                new Event
                {
                    EventFrom = new DateTime(2017, 2, 12, 9, 30, 0),
                    EventTo = new DateTime(2017, 2, 12, 11, 30, 0),
                    Username = "jason",
                    Activity = context.Activities.FirstOrDefault(a => a.ActivityDescription == "Watercolours Painting"),
                    CreationDate = new DateTime(2017, 2, 10, 9, 00, 0),
                    IsActive = false
                },
                new Event
                {
                    EventFrom = new DateTime(2017, 2, 12, 11, 30, 0),
                    EventTo = new DateTime(2017, 2, 12, 12, 30, 0),
                    Username = "jason",
                    Activity = context.Activities.FirstOrDefault(a => a.ActivityDescription == "Knitting & Crochet"),
                    CreationDate = new DateTime(2017, 2, 10, 9, 00, 0),
                    IsActive = false
                },
                new Event
                {
                    EventFrom = new DateTime(2017, 2, 12, 12, 30, 0),
                    EventTo = new DateTime(2017, 2, 12, 13, 30, 0),
                    Username = "jason",
                    Activity = context.Activities.FirstOrDefault(a => a.ActivityDescription == "Badminton"),
                    CreationDate = new DateTime(2017, 2, 10, 9, 00, 0),
                    IsActive = false
                },
                new Event
                {
                    EventFrom = new DateTime(2017, 2, 12, 13, 30, 0),
                    EventTo = new DateTime(2017, 2, 12, 14, 30, 0),
                    Username = "jason",
                    Activity = context.Activities.FirstOrDefault(a => a.ActivityDescription == "Dance"),
                    CreationDate = new DateTime(2017, 2, 10, 9, 00, 0),
                    IsActive = false
                },
                new Event
                {
                    EventFrom = new DateTime(2017, 2, 12, 14, 30, 0),
                    EventTo = new DateTime(2017, 2, 12, 15, 30, 0),
                    Username = "jason",
                    Activity = context.Activities.FirstOrDefault(a => a.ActivityDescription == "Floor Curling"),
                    CreationDate = new DateTime(2017, 2, 10, 9, 00, 0),
                    IsActive = false
                },
                //Day 2
                new Event
                {
                    EventFrom = new DateTime(2017, 2, 13, 8, 00, 0),
                    EventTo = new DateTime(2017, 2, 13, 8, 30, 0),
                    Username = "jason",
                    Activity = context.Activities.FirstOrDefault(a => a.ActivityDescription == "Nordic Pole Walking"),
                    CreationDate = new DateTime(2017, 2, 10, 9, 00, 0),
                    IsActive = true
                },
                new Event
                {
                    EventFrom = new DateTime(2017, 2, 13, 8, 30, 0),
                    EventTo = new DateTime(2017, 2, 13, 9, 30, 0),
                    Username = "jason",
                    Activity = context.Activities.FirstOrDefault(a => a.ActivityDescription == "Blood Pressure Screening"),
                    CreationDate = new DateTime(2017, 2, 10, 9, 00, 0),
                    IsActive = true
                },
                new Event
                {
                    EventFrom = new DateTime(2017, 2, 13, 9, 30, 0),
                    EventTo = new DateTime(2017, 2, 13, 11, 30, 0),
                    Username = "jason",
                    Activity = context.Activities.FirstOrDefault(a => a.ActivityDescription == "Senior Social and Fix-It Club Meeting"),
                    CreationDate = new DateTime(2017, 2, 10, 9, 00, 0),
                    IsActive = true
                },
                new Event
                {
                    EventFrom = new DateTime(2017, 2, 13, 11, 30, 0),
                    EventTo = new DateTime(2017, 2, 13, 12, 30, 0),
                    Username = "jason",
                    Activity = context.Activities.FirstOrDefault(a => a.ActivityDescription == "Lunch Break"),
                    CreationDate = new DateTime(2017, 2, 10, 9, 00, 0),
                    IsActive = true
                },
                new Event
                {
                    EventFrom = new DateTime(2017, 2, 13, 12, 30, 0),
                    EventTo = new DateTime(2017, 2, 13, 13, 30, 0),
                    Username = "jason",
                    Activity = context.Activities.FirstOrDefault(a => a.ActivityDescription == "55 Plus Travel Club Meeting"),
                    CreationDate = new DateTime(2017, 2, 10, 9, 00, 0),
                    IsActive = true
                },
                new Event
                {
                    EventFrom = new DateTime(2017, 2, 13, 13, 30, 0),
                    EventTo = new DateTime(2017, 2, 13, 14, 30, 0),
                    Username = "jason",
                    Activity = context.Activities.FirstOrDefault(a => a.ActivityDescription == "VGH Hospital Tour"),
                    CreationDate = new DateTime(2017, 2, 10, 9, 00, 0),
                    IsActive = true
                },
                new Event
                {
                    EventFrom = new DateTime(2017, 2, 13, 14, 30, 0),
                    EventTo = new DateTime(2017, 2, 13, 15, 30, 0),
                    Username = "jason",
                    Activity = context.Activities.FirstOrDefault(a => a.ActivityDescription == "Needle Arts Guild Event"),
                    CreationDate = new DateTime(2017, 2, 10, 9, 00, 0),
                    IsActive = true
                },
                new Event
                {
                    EventFrom = new DateTime(2017, 2, 13, 15, 30, 0),
                    EventTo = new DateTime(2017, 2, 13, 16, 30, 0),
                    Username = "jason",
                    Activity = context.Activities.FirstOrDefault(a => a.ActivityDescription == "Retirement Planning"),
                    CreationDate = new DateTime(2017, 2, 10, 9, 00, 0),
                    IsActive = true
                },
                //Day 3
                new Event
                {
                    EventFrom = new DateTime(2017, 2, 14, 8, 00, 0),
                    EventTo = new DateTime(2017, 2, 14, 8, 30, 0),
                    Username = "arnold",
                    Activity = context.Activities.FirstOrDefault(a => a.ActivityDescription == "Breakfast Club"),
                    CreationDate = new DateTime(2017, 2, 10, 9, 00, 0),
                    IsActive = true
                },
                new Event
                {
                    EventFrom = new DateTime(2017, 2, 14, 8, 30, 0),
                    EventTo = new DateTime(2017, 2, 14, 9, 30, 0),
                    Username = "arnold",
                    Activity = context.Activities.FirstOrDefault(a => a.ActivityDescription == "Fun Active Babes Snowshoeing"),
                    CreationDate = new DateTime(2017, 2, 10, 9, 00, 0),
                    IsActive = true
                },
                new Event
                {
                    EventFrom = new DateTime(2017, 2, 14, 9, 30, 0),
                    EventTo = new DateTime(2017, 2, 14, 11, 30, 0),
                    Username = "arnold",
                    Activity = context.Activities.FirstOrDefault(a => a.ActivityDescription == "Wit Knits"),
                    CreationDate = new DateTime(2017, 2, 10, 9, 00, 0),
                    IsActive = true
                },
                new Event
                {
                    EventFrom = new DateTime(2017, 2, 14, 11, 30, 0),
                    EventTo = new DateTime(2017, 2, 14, 12, 30, 0),
                    Username = "arnold",
                    Activity = context.Activities.FirstOrDefault(a => a.ActivityDescription == "Snowshoe 55 Club"),
                    CreationDate = new DateTime(2017, 2, 10, 9, 00, 0),
                    IsActive = true
                },
                new Event
                {
                    EventFrom = new DateTime(2017, 2, 14, 12, 30, 0),
                    EventTo = new DateTime(2017, 2, 14, 13, 30, 0),
                    Username = "arnold",
                    Activity = context.Activities.FirstOrDefault(a => a.ActivityDescription == "Oil & Acrylic Painting"),
                    CreationDate = new DateTime(2017, 2, 10, 9, 00, 0),
                    IsActive = true
                },
                new Event
                {
                    EventFrom = new DateTime(2017, 2, 14, 13, 30, 0),
                    EventTo = new DateTime(2017, 2, 14, 14, 30, 0),
                    Username = "arnold",
                    Activity = context.Activities.FirstOrDefault(a => a.ActivityDescription == "Badminton"),
                    CreationDate = new DateTime(2017, 2, 10, 9, 00, 0),
                    IsActive = true
                },
                new Event
                {
                    EventFrom = new DateTime(2017, 2, 14, 14, 30, 0),
                    EventTo = new DateTime(2017, 2, 14, 15, 30, 0),
                    Username = "arnold",
                    Activity = context.Activities.FirstOrDefault(a => a.ActivityDescription == "Billiards"),
                    CreationDate = new DateTime(2017, 2, 10, 9, 00, 0),
                    IsActive = true
                },
                new Event
                {
                    EventFrom = new DateTime(2017, 2, 14, 15, 30, 0),
                    EventTo = new DateTime(2017, 2, 14, 16, 30, 0),
                    Username = "arnold",
                    Activity = context.Activities.FirstOrDefault(a => a.ActivityDescription == "Computer Club"),
                    CreationDate = new DateTime(2017, 2, 10, 9, 00, 0),
                    IsActive = true
                },
                //Day 4
                new Event
                {
                    EventFrom = new DateTime(2017, 2, 15, 8, 30, 0),
                    EventTo = new DateTime(2017, 2, 15, 9, 30, 0),
                    Username = "arnold",
                    Activity = context.Activities.FirstOrDefault(a => a.ActivityDescription == "Book Club"),
                    CreationDate = new DateTime(2017, 2, 10, 9, 00, 0),
                    IsActive = true
                },
                new Event
                {
                    EventFrom = new DateTime(2017, 2, 15, 9, 30, 0),
                    EventTo = new DateTime(2017, 2, 15, 10, 30, 0),
                    Username = "arnold",
                    Activity = context.Activities.FirstOrDefault(a => a.ActivityDescription == "Table Tennis"),
                    CreationDate = new DateTime(2017, 2, 10, 9, 00, 0),
                    IsActive = true
                },
                new Event
                {
                    EventFrom = new DateTime(2017, 2, 15, 10, 30, 0),
                    EventTo = new DateTime(2017, 2, 15, 11, 30, 0),
                    Username = "arnold",
                    Activity = context.Activities.FirstOrDefault(a => a.ActivityDescription == "Carpet Bowling"),
                    CreationDate = new DateTime(2017, 2, 10, 9, 00, 0),
                    IsActive = true
                },
                new Event
                {
                    EventFrom = new DateTime(2017, 2, 15, 11, 30, 0),
                    EventTo = new DateTime(2017, 2, 15, 12, 30, 0),
                    Username = "arnold",
                    Activity = context.Activities.FirstOrDefault(a => a.ActivityDescription == "P.U.R.L.S (Knitting)"),
                    CreationDate = new DateTime(2017, 2, 10, 9, 00, 0),
                    IsActive = true
                },
                new Event
                {
                    EventFrom = new DateTime(2017, 2, 15, 12, 30, 0),
                    EventTo = new DateTime(2017, 2, 15, 13, 30, 0),
                    Username = "arnold",
                    Activity = context.Activities.FirstOrDefault(a => a.ActivityDescription == "Lunch Break"),
                    CreationDate = new DateTime(2017, 2, 10, 9, 00, 0),
                    IsActive = true
                },
                new Event
                {
                    EventFrom = new DateTime(2017, 2, 15, 13, 30, 0),
                    EventTo = new DateTime(2017, 2, 15, 14, 30, 0),
                    Username = "arnold",
                    Activity = context.Activities.FirstOrDefault(a => a.ActivityDescription == "Creative Writing"),
                    CreationDate = new DateTime(2017, 2, 10, 9, 00, 0),
                    IsActive = true
                },
                new Event
                {
                    EventFrom = new DateTime(2017, 2, 15, 14, 30, 0),
                    EventTo = new DateTime(2017, 2, 15, 16, 30, 0),
                    Username = "arnold",
                    Activity = context.Activities.FirstOrDefault(a => a.ActivityDescription == "Woodcarvers"),
                    CreationDate = new DateTime(2017, 2, 10, 9, 00, 0),
                    IsActive = true
                },
                //Day 5
                new Event
                {
                    EventFrom = new DateTime(2017, 2, 16, 8, 00, 0),
                    EventTo = new DateTime(2017, 2, 16, 8, 30, 0),
                    Username = "jason",
                    Activity = context.Activities.FirstOrDefault(a => a.ActivityDescription == "Breakfast Club"),
                    CreationDate = new DateTime(2017, 2, 10, 9, 00, 0),
                    IsActive = true
                },
                new Event
                {
                    EventFrom = new DateTime(2017, 2, 16, 8, 30, 0),
                    EventTo = new DateTime(2017, 2, 16, 9, 30, 0),
                    Username = "jason",
                    Activity = context.Activities.FirstOrDefault(a => a.ActivityDescription == "Pickle Ball"),
                    CreationDate = new DateTime(2017, 2, 10, 9, 00, 0),
                    IsActive = true
                },
                new Event
                {
                    EventFrom = new DateTime(2017, 2, 16, 9, 30, 0),
                    EventTo = new DateTime(2017, 2, 16, 13, 30, 0),
                    Username = "jason",
                    Activity = context.Activities.FirstOrDefault(a => a.ActivityDescription == "Bingo"),
                    CreationDate = new DateTime(2017, 2, 10, 9, 00, 0),
                    IsActive = true
                },
                new Event
                {
                    EventFrom = new DateTime(2017, 2, 16, 13, 30, 0),
                    EventTo = new DateTime(2017, 2, 16, 15, 30, 0),
                    Username = "jason",
                    Activity = context.Activities.FirstOrDefault(a => a.ActivityDescription == "Seniors’ Lounge"),
                    CreationDate = new DateTime(2017, 2, 10, 9, 00, 0),
                    IsActive = true
                },
                //Day 6
                new Event
                {
                    EventFrom = new DateTime(2017, 2, 17, 12, 30, 0),
                    EventTo = new DateTime(2017, 2, 17, 13, 30, 0),
                    Username = "jason",
                    Activity = context.Activities.FirstOrDefault(a => a.ActivityDescription == "Lunch Break"),
                    CreationDate = new DateTime(2017, 2, 10, 9, 00, 0),
                    IsActive = true
                },
                new Event
                {
                    EventFrom = new DateTime(2017, 2, 17, 13, 30, 0),
                    EventTo = new DateTime(2017, 2, 17, 15, 30, 0),
                    Username = "jason",
                    Activity = context.Activities.FirstOrDefault(a => a.ActivityDescription == "Pottery"),
                    CreationDate = new DateTime(2017, 2, 10, 9, 00, 0),
                    IsActive = true
                },
                new Event
                {
                    EventFrom = new DateTime(2017, 2, 17, 14, 30, 0),
                    EventTo = new DateTime(2017, 2, 17, 15, 30, 0),
                    Username = "jason",
                    Activity = context.Activities.FirstOrDefault(a => a.ActivityDescription == "Bingo"),
                    CreationDate = new DateTime(2017, 2, 10, 9, 00, 0),
                    IsActive = true
                },
                new Event
                {
                    EventFrom = new DateTime(2017, 2, 17, 15, 30, 0),
                    EventTo = new DateTime(2017, 2, 17, 16, 30, 0),
                    Username = "jason",
                    Activity = context.Activities.FirstOrDefault(a => a.ActivityDescription == "Retirement Planning"),
                    CreationDate = new DateTime(2017, 2, 10, 9, 00, 0),
                    IsActive = true
                },
                new Event
                {
                    EventFrom = new DateTime(2017, 2, 17, 16, 30, 0),
                    EventTo = new DateTime(2017, 2, 17, 17, 30, 0),
                    Username = "jason",
                    Activity = context.Activities.FirstOrDefault(a => a.ActivityDescription == "Creative Writing"),
                    CreationDate = new DateTime(2017, 2, 10, 9, 00, 0),
                    IsActive = true
                },
                new Event
                {
                    EventFrom = new DateTime(2017, 2, 17, 15, 30, 0),
                    EventTo = new DateTime(2017, 2, 17, 16, 30, 0),
                    Username = "jason",
                    Activity = context.Activities.FirstOrDefault(a => a.ActivityDescription == "Stamp Club"),
                    CreationDate = new DateTime(2017, 2, 10, 9, 00, 0),
                    IsActive = true
                }
            };

            return events.ToArray();
        }
    }
}
