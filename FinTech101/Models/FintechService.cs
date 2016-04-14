using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FinTech101.Models
{
    public class FintechService
    {
        public static List<SP_StockEntityWasUpOrDownByPercentResult> StockEntityWasUpOrDownByPercent(int setID, int seID, string upOrDown, decimal percent, int fromYear, int toYear)
        {
            using (ArgaamAnalyticsDataContext aadc = new ArgaamAnalyticsDataContext())
            {
                var result = aadc.SP_StockEntityWasUpOrDownByPercent(seID, setID, upOrDown, percent, fromYear, toYear);

                return result.ToList();
            }
        }

        public static List<SP_StockEntityUpDownMonthsResult> MonthsCompanyWasUpOrDown(int companyID, int fromYear, int toYear)
        {
            using (ArgaamAnalyticsDataContext aadc = new ArgaamAnalyticsDataContext())
            {
                var result = aadc.SP_StockEntityUpDownMonths(fromYear, toYear, companyID, 1).ToList();

                SP_StockEntityUpDownMonthsResult summaryRow = new SP_StockEntityUpDownMonthsResult();
                summaryRow.Year = 0;

                decimal[] positiveItems = new decimal[12]; // Enumerable.Repeat(0, 12).ToArray();
                decimal[] totalItems = new decimal[12];

                foreach (var item in result)
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

        /*
        public static List<SP_MonthsInWhichCompaniesWereUpAndDownResult> CompaniesWhichWereUpMoreThanEnnPercentOfTheTime(int fromYear, int toYear, decimal percent)
        {
            using (ArgaamAnalyticsDataContext aadc = new ArgaamAnalyticsDataContext())
            {
                var companies = (from p in aadc.Companies select p).ToList();

                var result = aadc.SP_MonthsInWhichCompaniesWereUpAndDown(fromYear, toYear).ToList();

                List<SP_MonthsInWhichCompaniesWereUpAndDownResult> retVal = new List<SP_MonthsInWhichCompaniesWereUpAndDownResult>();
                var distinctCompanyIDs = (from r in result
                                          select r.CompanyID).Distinct().ToList();

                foreach (int companyID in distinctCompanyIDs)
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
                    int startYear = 0;
                    int endYear = 0;
                    decimal yearsActive = 0;
                    int monthsActive = 0;

                    foreach (var item in companyRecords)
                    {
                        if (startYear == 0)
                        {
                            startYear = item.Year.Value;
                        }
                        endYear = item.Year.Value;

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
                                monthsActive++;
                            }
                        }

                        if (monthsActive < 12)
                        {
                            yearsActive += (decimal)monthsActive / 12;
                        }
                        else
                        {
                            yearsActive++;
                        }
                    }

                    bool includeSummary = false;

                    for (int i = 1; i <= 12; i++)
                    {
                        if (totalItems[i - 1] > 0)
                        {
                            var percentUp = positiveItems[i - 1] / totalItems[i - 1] * 100;
                            summaryRow.GetType().GetProperty("_" + i.ToString()).SetValue(summaryRow, new System.Nullable<Decimal>(percentUp));

                            if (percentUp >= percent)
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
                        summaryRow.StartYear = startYear;
                        summaryRow.EndYear = endYear;
                        summaryRow.YearsActive = yearsActive;

                        retVal.Add(summaryRow);
                    }
                }

                retVal = retVal.OrderByDescending(r => r.YearsActive).ToList();

                return (retVal);
            }
        }
        */

        /*
        public static List<TableRowViewModel> GetCompanyPriceAroundDates_UI(DateTime startsOn, DateTime? endsOn, int weeksBefore, int weeksAfter, int companyID)
        {
            var result = new List<TableRowViewModel>();
            var isRange = endsOn != null;
            var startsOnShortDateString = startsOn.ToShortDateString();
            var endsOnShortDateString = isRange ? endsOn.Value.ToShortDateString() : "";

            using (ArgaamAnalyticsDataContext aadc = new ArgaamAnalyticsDataContext())
            {
                var spResult = (aadc.SP_PricesAroundEvents(startsOn, endsOn, weeksBefore * -1, weeksAfter, companyID)).ToList();

                var resultDates = (from r in spResult
                                   group r by new { r.ForDate, r.DoW }
                                      into grp
                                   select new DateWithDoW
                                   {
                                       ForDate = grp.Key.ForDate.Value,
                                       DoW = grp.Key.DoW
                                   }).ToList();

                var companyName = (from p in aadc.Companies
                                   where p.CompanyID == companyID
                                   select p.CompanyNameEn).First();

                #region Compute EventDate Price or Last Valid price; Compute Fist and Last Valid Closing prices
                bool eventDateClosingPriceWasZero = false;
                decimal? eventDateClosingPrice = (from r in spResult
                                                  where r.CID == companyID
                                                  select r.Close).Skip(weeksBefore * 7).Take(1).First();
                DateTime closingPriceAltDate;
                decimal? firstValidClosingPrice = 0.0M;
                DateTime firstValidClosingPriceDate = DateTime.MinValue;
                decimal? lastValidClosingPrice = 0.0M;
                DateTime lastValidClosingPriceDate = DateTime.MinValue;
                int firstValidPriceIndex = -1;
                int lastValidPriceIndex = -1;

                if (eventDateClosingPrice.Value == 0)
                {
                    // Pick up the last closing value that was not 0
                    eventDateClosingPriceWasZero = true;
                    var a = (from r in spResult
                             where r.CID == companyID
                             && r.ForDate < startsOn
                             && r.Close != 0
                             orderby r.ForDate descending
                             select new
                             {
                                 r.ForDate,
                                 r.Close
                             }).Take(1).First();

                    eventDateClosingPrice = a.Close;
                    closingPriceAltDate = a.ForDate.Value;
                }


                var b = (from r in spResult
                         where r.CID == companyID
                         && r.Close != 0
                         orderby r.ForDate
                         select new
                         {
                             r.ForDate,
                             r.Close
                         }).Take(1).First();
                firstValidClosingPrice = b.Close;
                firstValidClosingPriceDate = b.ForDate.Value;

                var c = (from r in spResult
                         where r.CID == companyID
                         && r.Close != 0
                         orderby r.ForDate descending
                         select new
                         {
                             r.ForDate,
                             r.Close
                         }).Take(1).First();
                lastValidClosingPrice = c.Close;
                lastValidClosingPriceDate = c.ForDate.Value;
                #endregion

                #region Row 1 Header
                TableRowViewModel row1 = new TableRowViewModel();
                row1.TableCells.Add(new TableCellViewModel() { Text = "Dates / Commodity" });

                int startsOnIndex = -1, endsOnIndex = -1;
                int actualEventDatePriceIndex = -1;
                for (int i = 0; i < resultDates.Count; i++)
                {
                    var resultForDate = resultDates[i].ForDate;
                    var resultForDateShortDateString = resultForDate.ToShortDateString();
                    var cell = new TableCellViewModel() { Text = resultForDate.ToString("dd MM yyyy") + " " + resultDates[i].DoW };

                    if (resultForDateShortDateString == startsOnShortDateString)
                    {
                        cell.BackgroundColor = "lightblue";
                        startsOnIndex = i;
                    }
                    else if (isRange)
                    {
                        if (resultForDate > startsOn && resultForDate < endsOn)
                        {
                            if (i == startsOnIndex + 1)
                                cell.Text = "...";
                            else
                                continue;
                        }
                        else if (resultForDateShortDateString == endsOnShortDateString)
                        {
                            cell.BackgroundColor = "lightblue";
                            endsOnIndex = i;
                        }
                    }

                    row1.TableCells.Add(cell);
                }
                result.Add(row1);
                #endregion

                List<int> commodityIDArray = new List<int>() { 1, 3 };
                commodityIDArray.Add(companyID);
                decimal beforeEventChange = 0.0M, afteEventChange = 0.0M;

                #region Row 2 & 3 Brent & Crude
                foreach (var commodityID in commodityIDArray)
                {
                    bool isCompany = false;

                    TableRowViewModel row = new TableRowViewModel();
                    if (commodityID == 1)
                        row.TableCells.Add(new TableCellViewModel() { Text = "BRENT" });
                    else if (commodityID == 3)
                        row.TableCells.Add(new TableCellViewModel() { Text = "CRUDE" });
                    else {
                        row.TableCells.Add(new TableCellViewModel() { Text = companyName });
                        isCompany = true;
                    }

                    var filteredResults = spResult.Where(r => r.CID == commodityID).ToList();
                    for (int i = 0; i < filteredResults.Count; i++)
                    {
                        var item = filteredResults[i];
                        var cell = new TableCellViewModel() { Text = item.Close == 0 ? "" : item.Close.ToString() };

                        if(isCompany && firstValidPriceIndex == -1 && item.Close != 0)
                        {
                            firstValidPriceIndex = i;
                        }
                        if(isCompany && item.Close != 0)
                        {
                            lastValidPriceIndex = i;
                        }

                        if (i == startsOnIndex || i == endsOnIndex)
                        {
                            cell.BackgroundColor = "lightblue";

                            if (i == startsOnIndex && isCompany && eventDateClosingPriceWasZero)
                            {
                                int reverseIndex = i;

                                do
                                {
                                    reverseIndex--;
                                    if (filteredResults[reverseIndex].Close != 0)
                                    {
                                        break;
                                    }
                                } while (true);

                                for (int j = reverseIndex; j < i; j++)
                                {
                                    // J+1 cos the first cell is an info cell
                                    row.TableCells[j+1].BackgroundColor = "lightblue";
                                }
                            }
                        }
                        if (i > startsOnIndex && i < endsOnIndex)
                        {
                            if (i == startsOnIndex + 1)
                            {
                                cell.Text = "...";
                            }
                            else
                                continue;
                        }

                        row.TableCells.Add(cell);
                    }

                    result.Add(row);
                }
                #endregion

                TableRowViewModel row4 = new TableRowViewModel();
                row4.TableCells.Add(new TableCellViewModel());
                //bool closingRange

                for(int i=0;i<resultDates.Count;i++)
                {
                    TableCellViewModel cell = new TableCellViewModel();

                    if(i == firstValidPriceIndex)
                    {
                        var firstClosingPriceChangePercent = (((eventDateClosingPrice - firstValidClosingPrice) / firstValidClosingPrice) * 100);
                        cell.Text = firstClosingPriceChangePercent.Value.ToString("0.00") + "%";
                        cell.BackgroundColor = firstClosingPriceChangePercent >= 0 ? "lightgreen" : "red";
                        cell.ColSpan = startsOnIndex - firstValidPriceIndex;
                    }
                    else if((i > firstValidPriceIndex && i < startsOnIndex) ||
                        (((!isRange && i > startsOnIndex + 1) || (isRange && i > endsOnIndex + 1)) && i <= lastValidPriceIndex) ||
                        (isRange && i > startsOnIndex && i < endsOnIndex)
                        )
                    {
                        continue;
                    }
                    else if(i == startsOnIndex)
                    {
                        cell.BackgroundColor = "lightblue";
                    }
                    else if (isRange && i == endsOnIndex)
                    {
                        TableCellViewModel cellRange = new TableCellViewModel();
                        cellRange.Text = "...";
                        cell.BackgroundColor = cellRange.BackgroundColor = "lightblue";                        
                        row4.TableCells.Add(cellRange);
                    }
                    else if(((!isRange && i == startsOnIndex + 1) || (isRange && i == endsOnIndex + 1)) && i <= lastValidPriceIndex)
                    {
                        var lastClosingPriceChangePercent = (((lastValidClosingPrice - eventDateClosingPrice) / eventDateClosingPrice) * 100);
                        cell.Text = lastClosingPriceChangePercent.Value.ToString("0.00") + "%";
                        cell.BackgroundColor = lastClosingPriceChangePercent >= 0 ? "lightgreen" : "red";
                        cell.ColSpan = lastValidPriceIndex - ((isRange) ? endsOnIndex : startsOnIndex);
                    }

                    row4.TableCells.Add(cell);
                }

                result.Add(row4);
            }

            return (result);
        }
        */
    }
}