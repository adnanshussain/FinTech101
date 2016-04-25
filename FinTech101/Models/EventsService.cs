using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FinTech101.Models
{
    public class EventsService
    {
        public static List<EventCategory> GetAllEventCategories()
        {
            using (ArgaamAnalyticsDataContext aadc = new ArgaamAnalyticsDataContext())
            {
                return ((from p in aadc.EventCategories select p).ToList());
            }
        }

        public static List<EventCategory> GetAllParentEventCategories()
        {
            using (ArgaamAnalyticsDataContext aadc = new ArgaamAnalyticsDataContext())
            {
                return ((from p in aadc.EventCategories where !p.IsSubcategory select p).ToList());
            }
        }

        public static List<EventCategory> GetAllEventSubCategories(int parentEventCatID)
        {
            using (ArgaamAnalyticsDataContext aadc = new ArgaamAnalyticsDataContext())
            {
                return ((from p in aadc.EventCategories where p.ParentCategoryID == parentEventCatID select p).ToList());
            }
        }

        public static void AddEventCategory(EventCategory newEventCategory)
        {
            using (ArgaamAnalyticsDataContext aadc = new ArgaamAnalyticsDataContext())
            {
                aadc.EventCategories.InsertOnSubmit(newEventCategory);
                aadc.SubmitChanges();
            }
        }

        public static List<Event> GetAllEvents()
        {
            using (ArgaamAnalyticsDataContext aadc = new ArgaamAnalyticsDataContext())
            {
                return ((from p in aadc.Events select p).ToList());
            }
        }
    }
}