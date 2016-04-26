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
        public ActionResult ListEventCategories()
        {
            ViewData["result"] = EventsService.GetAllEventCategories();

            return (View());
        }

        public ActionResult AddEventCategory()
        {
            var parentCategories = EventsService.GetAllParentEventCategories();
            ViewData["ParentCategories_SL"] = new SelectList(parentCategories.AsEnumerable().Select((item, index) => new SelectListItem() { Text = item.EventCategoryName, Value = item.EventCategoryID.ToString() }).ToList<SelectListItem>(), "Value", "Text");

            return (View());
        }

        [HttpPost]
        public JsonResult AddEventCategory(EventCategory postedData)
        {
            EventsService.AddEventCategory(postedData);

            return (Json("success"));
        }

        public ActionResult ListEvents()
        {
            using (ArgaamAnalyticsDataContext aadc = new ArgaamAnalyticsDataContext())
            {
                ViewData["filteredEvents"] = EventsService.GetAllEvents();

                ViewData["companies_SL"] = new SelectList(FintechService.GetStockEntities(1).AsEnumerable().Select((item, index) => new SelectListItem() { Value = item.StockEntityID.ToString(), Text = item.NameEn }), "Value", "Text");
                var eventCatSLI = EventsService.GetAllParentEventCategories().AsEnumerable().Select((item, index) => new SelectListItem() { Value = item.EventCategoryID.ToString(), Text = item.EventCategoryName }).ToList();
                eventCatSLI.Insert(0, new SelectListItem() { Text = "ANY", Value = "0" });
                ViewData["parentEventCategories_SL"] = new SelectList(eventCatSLI, "Value", "Text");
            }

            return (View());
        }

        public ActionResult EventSubCategoryDropDown(int? parentEventCategoryID)
        {

            if (parentEventCategoryID.HasValue && parentEventCategoryID.Value != 0)
            {
                var sli = EventsService.GetAllEventSubCategories(parentEventCategoryID.Value).AsEnumerable().Select((item, index) => new SelectListItem() { Value = item.EventCategoryID.ToString(), Text = item.EventCategoryName }).ToList();
                if(sli.Count > 0)
                {
                    ViewData["result"] = new SelectList(sli, "Value", "Text");
                }
            }                

            return (View());
        }

        public ActionResult ListEventsFiltered(int eventClass, int companyEventType, int companyID, int eventCategoryID, int? eventSubCategoryID)
        {
            using (ArgaamAnalyticsDataContext aadc = new ArgaamAnalyticsDataContext())
            {
                var events = (from p in aadc.Events
                              where 
                                (eventClass == 1 && p.EventClassification == eventClass && (companyEventType == 0 || (p.CompanyEventType == companyEventType)) && (companyID == p.CompanyID) && (eventCategoryID == 0 || p.EventCategoryID == eventCategoryID || (eventSubCategoryID.HasValue && p.EventCategoryID == eventSubCategoryID)))
                                || 
                                (eventClass == 2 && p.EventClassification == eventClass && (eventCategoryID == 0 || p.EventCategoryID == eventCategoryID || (eventSubCategoryID.HasValue && p.EventCategoryID == eventSubCategoryID)))
                              orderby p.StartsOn
                              select p).ToList();

                ViewData["filteredEvents"] = events;
            }

            return (PartialView("_eventsList"));
        }

        public ActionResult AddEvent()
        {
            using (ArgaamAnalyticsDataContext aadc = new ArgaamAnalyticsDataContext())
            {
                var eventCatSLI = EventsService.GetAllParentEventCategories().AsEnumerable().Select((item, index) => new SelectListItem() { Value = item.EventCategoryID.ToString(), Text = item.EventCategoryName }).ToList();
                ViewData["parentEventCategories_SL"] = new SelectList(eventCatSLI, "Value", "Text");
                ViewData["companies_SL"] = new SelectList(FintechService.GetStockEntities(1).AsEnumerable().Select((item, index) => new SelectListItem() { Value = item.StockEntityID.ToString(), Text = item.NameEn }), "Value", "Text");
            }

            return (View());
        }

        [HttpPost]
        public JsonResult AddEvent(Event globalEvent)
        {
            using (ArgaamAnalyticsDataContext aadc = new ArgaamAnalyticsDataContext())
            {
                aadc.Events.InsertOnSubmit(globalEvent);
                aadc.SubmitChanges();
            }

            return (Json("SUCCESS"));
        }

        public JsonResult DeleteEvent(int eventID)
        {
            using (ArgaamAnalyticsDataContext aadc = new ArgaamAnalyticsDataContext())
            {
                //var ge = (from rec in aadc.GlobalEvents
                //          where rec.GlobalEventID == eventID
                //          select rec).Single();

                var ge = new Event() { EventID = eventID };

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