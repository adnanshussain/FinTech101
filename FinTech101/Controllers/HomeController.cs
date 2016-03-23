using FinTech101.Models;
using System;
using System.Collections.Generic;
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

        public ActionResult fintech()
        {
            using (ArgaamAnalyticsDataContext aadc = new ArgaamAnalyticsDataContext())
            {
                var companies = from p in aadc.Companies
                                where p.IsActive == true
                                && p.HasOnlyBasicProfile == false
                                && p.MarketStatusID == 3
                                orderby p.ShortNameEn
                                select new
                                {
                                    Value = p.CompanyID,
                                    Text = p.ShortNameEn + " - " + p.CompanyNameEn
                                };
                ViewBag.AllCompanies = companies.AsEnumerable().Select((item, index) => new SelectListItem() { Value = item.Value.ToString(), Text = item.Text }).ToList<SelectListItem>();

                var events = from p in aadc.GlobalEvents
                             select new
                             {
                                 Value = p.GlobalEventID,
                                 Text = p.EventDesc, 
                                 Date = p.OccuredOn
                             };
                ViewBag.AllEvents = events.AsEnumerable().Select((item, index) => new SelectListItem() { Value = item.Value.ToString(), Text = item.Text + " [" + item.Date.ToString("dd MMM yyyy") + "]" }).ToList<SelectListItem>();
        }

            List<String> years = new List<string>();
            for (int i = 1993; i<= 2016; i++)
            {
                years.Add(i.ToString());
            }

            ViewBag.AllYearsSL = new SelectList(years.Select(year => new SelectListItem() { Value = year, Text = year }), "Value", "Text");

            return View();
        }

        public ActionResult q1(int companyID, string upOrDown, float percent, int fromYear, int toYear)
        {
            var result = FintechService.CompanyWasUpOrDownByPercent(companyID, upOrDown, percent, fromYear, toYear);

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

        public ActionResult q2(int companyID, int year)
        {
            using (ArgaamAnalyticsDataContext aadc = new ArgaamAnalyticsDataContext())
            {
                var result = aadc.SP_CommpanyGoodAndBadDays(companyID, year);

                ViewBag.result = result.ToList();
            }

            return PartialView();
        }

        // Months company was up or down
        public ActionResult q3(int companyID, int from_year, int to_year, bool isPartial)
        {
            ViewBag.result = FintechService.MonthsCompanyWasUpOrDown(companyID, from_year, to_year);

            ViewBag.CompanyName = FintechService.GetCompany(companyID).CompanyNameEn;

            ViewBag.isPartial = isPartial;

            return PartialView();
        }

        // Which companies were up more than n percent in selected date range
        public ActionResult q5(int from_year, int to_year, decimal percent)
        {
            ViewBag.result = FintechService.CompaniesWhichWereUpMoreThanEnnPercentOfTheTime(from_year, to_year, percent);

            ViewBag.percent = percent;
            ViewBag.fromYear = from_year;
            ViewBag.toYear = to_year;

            return PartialView();
        }

        public ActionResult q4(int eventID, int weeksBefore, int weeksAfter, int companyID)
        {
            using (ArgaamAnalyticsDataContext aadc = new ArgaamAnalyticsDataContext())
            {
                var eventDate = (from p in aadc.GlobalEvents
                                where p.GlobalEventID == eventID
                                select p.OccuredOn).FirstOrDefault();

                var result = (aadc.SP_PricesAroundEvents(eventDate, weeksBefore * -1, weeksAfter, companyID)).ToList();

                ViewBag.eventDate = eventDate;

                ViewBag.result = result;

                ViewBag.resultDates = (from r in result
                                      group r by new { r.ForDate, r.DoW }
                                      into grp
                                      select new DateWithDoW
                                      {
                                          ForDate = grp.Key.ForDate.Value,
                                          DoW = grp.Key.DoW
                                      }).ToList();

                ViewBag.CompanyID = companyID;
                ViewBag.CompanyName = (from p in aadc.Companies
                                       where p.CompanyID == companyID
                                       select p.CompanyNameEn).FirstOrDefault();

                ViewBag.eventDateClosingPrice = (from r in result
                                                 where r.CID == companyID
                                                 select r.Close).Skip(weeksBefore * 7).Take(1).First();
                ViewBag.minClose = (from r in result
                                    where r.CID == companyID
                                    && r.Close > 0
                                    select r.Close).Min().Value;
                ViewBag.maxClose = (from r in result
                                    where r.CID == companyID
                                    select r.Close).Max().Value;

            }

            return (PartialView());
        }

        public JsonResult q3_json(int companyID, int from_year, int to_year)
        {
            using (ArgaamAnalyticsDataContext aadc = new ArgaamAnalyticsDataContext())
            {
                var result = aadc.SP_MonthsCompanyWasUpOrDown(from_year, to_year, companyID);

                ViewBag.result = result.ToList();
            }

            return Json(ViewBag.result, JsonRequestBehavior.AllowGet);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}