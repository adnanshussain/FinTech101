using FinTech101.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace FinTech101.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Fintech(int setID = 1)
        {
            FintechHomeViewModel model = new FintechHomeViewModel();

            using (ArgaamAnalyticsDataContext aadc = new ArgaamAnalyticsDataContext())
            {
                var stockEntityTypes = from p in aadc.StockEntityTypes
                                       select new ValueTextModel
                                       {
                                           Value = p.StockEntityTypeID,
                                           Text = p.StockEntityTypeName
                                       };
                model.StockEntityTypes = new SelectList(stockEntityTypes.AsEnumerable().Select((item, index) => new SelectListItem() { Value = item.Value.ToString(), Text = item.Text }).ToList<SelectListItem>(), "Value", "Text", setID);
                model.SelectedSET = (from p in stockEntityTypes where p.Value == setID select p).First();

                var stockEntities = from p in aadc.StockEntities
                                    where p.StockEntityTypeID == setID
                                    orderby p.NameEn
                                    select p;
                model.StockEntities = new SelectList(stockEntities.AsEnumerable().Select((item, index) => new SelectListItem() { Value = item.StockEntityID.ToString(), Text = item.NameEn }).ToList<SelectListItem>(), "Value", "Text");

                var commodityStockEntities = from p in aadc.StockEntities
                                             where p.StockEntityTypeID == 5
                                             orderby p.NameEn
                                             select p;
                model.CommodityStockEntities = new SelectList(commodityStockEntities.AsEnumerable().Select((item, index) => new SelectListItem() { Value = item.StockEntityID.ToString(), Text = item.NameEn }).ToList<SelectListItem>(), "Value", "Text");

                model.SetMinYear = (from p in aadc.StockEntityPrices where p.StockEntityTypeID == setID select p.ForDate).Min().Value.Year;
                model.SetMaxYear = (from p in aadc.StockEntityPrices where p.StockEntityTypeID == setID select p.ForDate).Max().Value.Year;
                List<String> years = new List<string>();
                for (int i = model.SetMinYear; i <= model.SetMaxYear; i++)
                {
                    years.Add(i.ToString());
                }

                model.SetActiveYears_From = new SelectList(years.Select(year => new SelectListItem() { Value = year, Text = year }), "Value", "Text", model.SetMinYear);
                model.SetActiveYears_To = new SelectList(years.Select(year => new SelectListItem() { Value = year, Text = year }), "Value", "Text", model.SetMaxYear);

                var events = from p in aadc.Events
                             select new
                             {
                                 Value = p.EventID,
                                 Desc = p.EventDesc,
                                 StartDate = p.StartsOn,
                                 EndDate = p.EndsOn
                             };
                ViewBag.AllEvents = events.AsEnumerable().Select((item, index) => new SelectListItem() { Value = item.Value.ToString(), Text = item.Desc /*+ " [" + item.StartDate.ToString("dd MMM yyyy") + "]"*/ }).ToList<SelectListItem>();

                model.CompanyEventTypes = new SelectList(new List<SelectListItem>()
                {
                    new SelectListItem() { Value = "1", Text = "Earning Announcements" },
                    new SelectListItem() { Value = "2", Text = "Dividend Announcements" }
                }, "Value", "Text");
            }

            return View(model);
        }

        // On what dates was the Stock of an entity up and or down by 'n' percent in a Date Range
        public ActionResult q1(int setID /* StockEntityTypeID */, int seID /* StockEntityID */, string upOrDown, decimal percent, int fromYear, int toYear)
        {
            var result = FintechService.StockEntityWasUpOrDownByPercent(setID, seID, upOrDown, percent, fromYear, toYear);

            ViewBag.result = result;

            ViewBag.years = (from p in result
                             group p by p.year into g
                             select new KeyAndCount
                             {
                                 Key = g.Key.ToString(),
                                 Count = g.Count()
                             }).ToList();

            return PartialView();
        }

        // What were the number of good / bad / neutral days for a Stock Entity in a specified year
        public ActionResult q2(int setID, int seID, int year)
        {
            using (ArgaamAnalyticsDataContext aadc = new ArgaamAnalyticsDataContext())
            {
                var result = aadc.SP_Q2_StockEntityGoodAndBadDays(seID, setID, year);

                ViewBag.result = result.ToList();
            }

            return PartialView();
        }

        // Months in which a Stock entity was up or down in a date range
        public ActionResult q3(int setID, int seID, int from_year, int to_year, bool isPartial)
        {
            ViewData["RESULT"] = FintechService.StockEntityWasUpOrDownMonths(setID, seID, from_year, to_year);
            ViewData["SE"] = FintechService.GetStockEntity(setID, seID);

            ViewBag.isPartial = isPartial;

            return PartialView();
        }
        public JsonResult q3_json(int companyID, int from_year, int to_year)
        {
            using (ArgaamAnalyticsDataContext aadc = new ArgaamAnalyticsDataContext())
            {
                //var result = aadc.SP_MonthsCompanyWasUpOrDown(from_year, to_year, companyID);

                //ViewBag.result = result.ToList();
            }

            return Json(ViewBag.result, JsonRequestBehavior.AllowGet);
        }

        // Which companies were up more than n percent in selected date range
        public ActionResult q5(int setID, int from_year, int to_year, decimal percent)
        {
            ViewBag.result = FintechService.StockEntityTypesWhichWereUpMoreThanEnnPercentOfTheTime(setID, from_year, to_year, percent);

            ViewBag.percent = percent;
            ViewBag.fromYear = from_year;
            ViewBag.toYear = to_year;
            ViewBag.setID = setID;

            using (ArgaamAnalyticsDataContext aadc = new ArgaamAnalyticsDataContext())
            {
                ViewData["SELECTED_SET"] = (from p in aadc.StockEntityTypes where p.StockEntityTypeID == setID select p).First();
            }

            return PartialView();
        }

        public ActionResult q4(int setID, int seID, int eventID, int daysBefore, int daysAfter, bool isPartial = false)
        {
            List<TableRowViewModel> model = null;
            Q4_ViewModel newResult = null;

            using (ArgaamAnalyticsDataContext aadc = new ArgaamAnalyticsDataContext())
            {
                var eventDate = (from p in aadc.Events
                                 where p.EventID == eventID
                                 select new
                                 {
                                     StartDate = p.StartsOn,
                                     EndDate = p.EndsOn
                                 }).FirstOrDefault();
                try
                {
                    //model = FintechService.GetStockEntityPricesAroundDates_UI(setID, seID, eventDate.StartDate, eventDate.EndDate.HasValue ? eventDate.EndDate : null, daysBefore, daysAfter);
                    newResult = FintechService.GetStockEntityPricesAroundDates(setID, seID, eventDate.StartDate, eventDate.EndDate, daysBefore, daysAfter);
                }
                catch (Exception ex)
                {

                }
            }

            ViewBag.isPartial = isPartial;

            if (isPartial)
                return (PartialView("q4_pivoted", newResult));
            else
                return (View("q4_pivoted", newResult));
        }

        public ActionResult q4_1(int setID, int eventID, int daysBefore, int daysAfter)
        {
            Q4_1_Model model = new Q4_1_Model();
            model.SetID = setID;
            model.EventID = eventID;

            using (ArgaamAnalyticsDataContext aadc = new ArgaamAnalyticsDataContext())
            {
                var eventDate = (from p in aadc.Events
                                 where p.EventID == eventID
                                 select new
                                 {
                                     StartDate = p.StartsOn,
                                     EndDate = p.EndsOn
                                 }).FirstOrDefault();

                model.IsRangeEvent = eventDate.EndDate.HasValue ? true : false;

                model.Result = FintechService.GetAllStockEntityPricesAroundDates(setID, null, eventDate.StartDate, eventDate.EndDate.HasValue ? eventDate.EndDate : null, daysBefore, daysAfter);

                model.DaysBefore = daysBefore;
                model.DaysAfter = daysAfter;
            }

            return (View("q4_1", model));
        }

        public ActionResult q4_2(int seID, int companyEventType, int daysBefore, int daysAfter)
        {
            DataTable result;

            using (ArgaamAnalyticsDataContext aadc = new ArgaamAnalyticsDataContext())
            {
                result = FintechService.GetPricesChangeBasedOnCompanyEvent(seID,companyEventType, daysBefore, daysAfter);
            }

            return (PartialView("q4_2", result));
        }

        public ActionResult q7(int anchorSeID, int targetSetID, int targetSeID, decimal anchorPercent, int targetAfterDays, int fromYear, int toYear)
        {
            using (ArgaamAnalyticsDataContext aadc = new ArgaamAnalyticsDataContext())
            {
                ViewData["result"] = aadc.SP_Q7_GetStockEntityPricesBasedOnSomeOtherStockEntity(5, anchorSeID, targetSetID, targetSeID, anchorPercent, targetAfterDays, fromYear, toYear).ToList();
            }

            return (View());
        }
    }
}