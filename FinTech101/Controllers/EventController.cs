using FinTech101.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FinTech101.Controllers
{
    public class EventController : Controller
    {
        public ActionResult ListEvents()
        {
            using (ArgaamAnalyticsDataContext aadc = new ArgaamAnalyticsDataContext())
            {
                var events = (from p in aadc.Events
                                  //where (eventCategoryID > 0 && p.EventCategoryID == eventCategoryID) || true
                              orderby p.StartsOn
                              select p).ToList();

                ViewBag.allEvents = events;

                var eventCategories = (from p in aadc.EventCategories
                                       select p).ToList();

                var allEventCategories = eventCategories.AsEnumerable().Select((item, index) => new SelectListItem() { Value = item.EventCategoryID.ToString(), Text = item.EventCategoryName }).ToList<SelectListItem>();
                allEventCategories.Insert(0, new SelectListItem() { Value = "0", Text = "SHOW ALL" });

                ViewBag.allEventCategories = allEventCategories;
            }

            return (View());
        }

        public ActionResult EventsList(int eventCategoryID = 0)
        {
            using (ArgaamAnalyticsDataContext aadc = new ArgaamAnalyticsDataContext())
            {
                var events = (from p in aadc.Events
                              where (eventCategoryID > 0 && p.EventCategoryID == eventCategoryID) || (eventCategoryID == 0)
                              orderby p.StartsOn
                              select p).ToList();

                ViewBag.allEvents = events;
            }

            return (PartialView("_eventsList"));
        }

        public ActionResult AddEvent()
        {
            using (ArgaamAnalyticsDataContext aadc = new ArgaamAnalyticsDataContext())
            {
                var eventCategories = (from p in aadc.EventCategories
                                       select p).ToList();

                var allEventCategories = eventCategories.AsEnumerable().Select((item, index) => new SelectListItem() { Value = item.EventCategoryID.ToString(), Text = item.EventCategoryName }).ToList<SelectListItem>();

                ViewBag.allEventCategories = allEventCategories;
            }

            return (View());
        }

        [HttpPost]
        public ActionResult AddEvent(Event globalEvent)
        {
            using (ArgaamAnalyticsDataContext aadc = new ArgaamAnalyticsDataContext())
            {
                aadc.Events.InsertOnSubmit(globalEvent);
                aadc.SubmitChanges();
            }

            return (Redirect("/home/listevents"));
        }

        public JsonResult DeleteEvent(int eventID)
        {
            using (ArgaamAnalyticsDataContext aadc = new ArgaamAnalyticsDataContext())
            {
                //var ge = (from rec in aadc.GlobalEvents
                //          where rec.GlobalEventID == eventID
                //          select rec).Single();

                var ge = new Event() { GlobalEventID = eventID };

                aadc.Events.Attach(ge);
                aadc.Events.DeleteOnSubmit(ge);
                aadc.SubmitChanges();
            }

            return (Json("SUCCESS", JsonRequestBehavior.AllowGet));
        }

        public ActionResult AddGlobalEvent()
        {
            return (View());
        }
    }
}