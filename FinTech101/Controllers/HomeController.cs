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
            using (ArgPlusKenshoDataContext dc = new ArgPlusKenshoDataContext())
            {
                var companies = from p in dc.Companies
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
            }

            List<String> years = new List<string>();
            for (int i = 1993; i<= 2016; i++)
            {
                years.Add(i.ToString());
            }

            ViewBag.AllYearsSL = new SelectList(years.Select(year => new SelectListItem() { Value = year, Text = year }), "Value", "Text");

            return View();
        }

        public ActionResult q1(int companyID, string upOrDown, float percent, int year)
        {
            using (ArgPlusKenshoDataContext dc = new ArgPlusKenshoDataContext())
            {
                var result = dc.SP_CompanyUpOrDownByPercent(companyID, upOrDown, (decimal) percent, year);

                ViewBag.dates = result.ToList();
            }

            return PartialView();
        }

        public ActionResult q2(int companyID, int year)
        {
            using (ArgPlusKenshoDataContext dc = new ArgPlusKenshoDataContext())
            {
                var result = dc.SP_CommpanyGoodAndBadDays(companyID, year);

                ViewBag.result = result.ToList();
            }

            return PartialView();
        }

        public ActionResult q3(int companyID, int from_year, int to_year)
        {
            using (ArgPlusKenshoDataContext dc = new ArgPlusKenshoDataContext())
            {
                var result = dc.SP_MonthsCompanyWasUpOrDown(from_year, to_year, companyID);

                ViewBag.result = result.ToList();
            }

            return PartialView();
        }

        public JsonResult q3_json(int companyID, int from_year, int to_year)
        {
            using (ArgPlusKenshoDataContext dc = new ArgPlusKenshoDataContext())
            {
                var result = dc.SP_MonthsCompanyWasUpOrDown(from_year, to_year, companyID);

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