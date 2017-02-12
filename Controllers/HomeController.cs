using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ZenithDataLib.Models;
using System.Data.Entity;

namespace ZenithWebSite.Controllers
{
    public class HomeController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        public ActionResult Index()
        {
            DateTime mondayDate = DateTime
                          .Today
                          .AddDays(((int)(DateTime.Today.DayOfWeek) * -1) + 1);

            DateTime sundayDate = DateTime
                          .Today
                          .AddDays(((int)(DateTime.Today.DayOfWeek) * -1) + 8);

            var events = db.Events.Include(e => e.Activity).ToList();
            events = events.OrderBy(e => e.EventFrom)
                .Where(e => e.EventFrom >= mondayDate && e.EventFrom <= sundayDate)
                .ToList();

            var eventsDetail = new Dictionary<string, List<Event>>();

            foreach (var i in events)
            {
                if (eventsDetail.ContainsKey(i.EventFrom.ToLongDateString()))
                {
                    eventsDetail[i.EventFrom.ToLongDateString()].Add(i);
                }
                else
                {
                    eventsDetail[i.EventFrom.ToLongDateString()] = new List<Event>();
                    eventsDetail[i.EventFrom.ToLongDateString()].Add(i);
                }
            }

            return View(eventsDetail);
        }
    }
}