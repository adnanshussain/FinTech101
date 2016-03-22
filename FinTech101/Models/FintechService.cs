using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FinTech101.Models
{
    public class FintechService
    {
        public static List<SP_CompanyUpOrDownByPercentResult> CompanyWasUpOrDownByPercent(int companyID, string upOrDown, float percent, int fromYear, int toYear)
        {
            using (ArgaamAnalyticsDataContext aadc = new ArgaamAnalyticsDataContext())
            {
                var result = aadc.SP_CompanyUpOrDownByPercent(companyID, upOrDown, (decimal)percent, fromYear, toYear);

                return result.ToList();
            }
        }

        public static List<SP_MonthsCompanyWasUpOrDownResult> MonthsCompanyWasUpOrDown(int companyID, int fromYear, int toYear)
        {
            using (ArgaamAnalyticsDataContext aadc = new ArgaamAnalyticsDataContext())
            {
                var result = aadc.SP_MonthsCompanyWasUpOrDown(fromYear, toYear, companyID).ToList();

                SP_MonthsCompanyWasUpOrDownResult summaryRow = new SP_MonthsCompanyWasUpOrDownResult();
                summaryRow.Year = 0;

                decimal[] positiveItems = new decimal[12]; // Enumerable.Repeat(0, 12).ToArray();
                decimal[] totalItems = new decimal[12];

                foreach (var item in result)
                {
                    for(int i = 1; i <= 12; i++)
                    {
                        decimal? value = (decimal?) item.GetType().GetProperty("_" + i.ToString()).GetValue(item);
                        if(value.HasValue)
                        {
                            totalItems[i-1]++;
                            if(value.Value > 0)
                            {
                                positiveItems[i-1]++;
                            }
                        }
                    }
                }

                for (int i = 1; i <= 12; i++)
                {
                    if (totalItems[i - 1] > 0)
                    {
                        var percentUp = positiveItems[i - 1] / totalItems[i - 1] * 100;
                        summaryRow.GetType().GetProperty("_" + i.ToString()).SetValue(summaryRow, new System.Nullable<Decimal>(percentUp));

                        //if (percentUp >= percent)
                        //{
                        //    includeSummary = true;
                        //}
                    }
                    else
                    {
                        summaryRow.GetType().GetProperty("_" + i.ToString()).SetValue(summaryRow, new System.Nullable<Decimal>(0));
                    }
                    //summaryRow.GetType().GetProperty("_" + i.ToString()).SetValue(summaryRow, new System.Nullable<Decimal>(positiveItems[i-1] / totalItems[i-1] * 100));
                }

                result.Add(summaryRow);

                return (result);
            }
        }

        public static List<SP_MonthsInWhichCompaniesWereUpAndDownResult> CompaniesWhichWereUpMoreThanEnnPercentOfTheTime(int fromYear, int toYear, decimal percent)
        {
            using (ArgaamAnalyticsDataContext aadc = new ArgaamAnalyticsDataContext())
            {
                var companies = (from p in aadc.Companies select p).ToList();

                var result = aadc.SP_MonthsInWhichCompaniesWereUpAndDown(fromYear, toYear).ToList();

                List<SP_MonthsInWhichCompaniesWereUpAndDownResult> retVal = new List<SP_MonthsInWhichCompaniesWereUpAndDownResult>();
                var distinctCompanyIDs = (from r in result
                                          select r.CompanyID).Distinct().ToList();

                foreach(int companyID in distinctCompanyIDs)
                {
                    var companyRecords = (from r in result
                                          where r.CompanyID == companyID
                                          select r).ToList();

                    SP_MonthsInWhichCompaniesWereUpAndDownResult summaryRow = new SP_MonthsInWhichCompaniesWereUpAndDownResult();
                    summaryRow.CompanyName = (from c in companies where c.CompanyID == companyID select c.CompanyNameEn).FirstOrDefault();
                    summaryRow.CompanyID = companyID;
                    summaryRow.Year = 0;

                    decimal[] positiveItems = new decimal[12]; // Enumerable.Repeat(0, 12).ToArray();
                    decimal[] totalItems = new decimal[12];

                    foreach (var item in companyRecords)
                    {
                        for (int i = 1; i <= 12; i++)
                        {
                            decimal? value = (decimal?)item.GetType().GetProperty("_" + i.ToString()).GetValue(item);
                            if (value.HasValue)
                            {
                                totalItems[i - 1]++;
                                if (value.Value > 0)
                                {
                                    positiveItems[i - 1]++;
                                }
                            }
                        }
                    }

                    bool includeSummary = false;

                    for (int i = 1; i <= 12; i++)
                    {
                        if (totalItems[i - 1] > 0)
                        {
                            var percentUp = positiveItems[i - 1] / totalItems[i - 1] * 100;
                            summaryRow.GetType().GetProperty("_" + i.ToString()).SetValue(summaryRow, new System.Nullable<Decimal>(percentUp));

                            if(percentUp >= percent)
                            {
                                includeSummary = true;
                            }
                        }
                        else
                        {
                            summaryRow.GetType().GetProperty("_" + i.ToString()).SetValue(summaryRow, new System.Nullable<Decimal>(0));
                        }
                    }

                    if (includeSummary)
                    {
                        retVal.Add(summaryRow);
                    }
                }

                return (retVal);
            }
        }
    }
}