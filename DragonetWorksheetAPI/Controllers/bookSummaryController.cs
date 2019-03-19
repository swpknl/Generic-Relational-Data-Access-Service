using DataAccess.Contracts;
using DataAccess.Impl;
using Entities.Impl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace DragonetWorksheetAPI.Controllers
{
    public class bookSummaryController : ApiController
    {
        [HttpGet]
        public IEnumerable<object> getBookSummary(string uid, int pageSize, int offSet)
        {
            IRepository<BookSummary> repository = new Repository<BookSummary>();
            var interimResults = repository.ExecuteStoredProcedure(new { user_id = uid }).GroupBy(x => x.trading_book);
            var buc_criteria_lines = new Repository<BUCCriteriaLine>().GetAllEntities(new { param1 = uid });
            var pv = buc_criteria_lines.FirstOrDefault(x => x.user_id.Trim().Equals(uid, StringComparison.OrdinalIgnoreCase) && x.type.Trim().Equals("pv_tol", StringComparison.OrdinalIgnoreCase));
            var pl = buc_criteria_lines.FirstOrDefault(x => x.user_id.Trim().Equals(uid, StringComparison.OrdinalIgnoreCase) && x.type.Trim().Equals("pl_tol", StringComparison.OrdinalIgnoreCase));
            var breaks = buc_criteria_lines.FirstOrDefault(x => x.user_id.Trim().Equals(uid, StringComparison.OrdinalIgnoreCase) && x.type.Trim().Equals("breaks", StringComparison.OrdinalIgnoreCase));
            var results = new List<CalculatedBookSummary>();
            int breaksCounter = 0;
            int wreasonCounter = 0;
            int matchedCounter = 0;
            int positionCounter = 0;
            int pandlCounter = 0;
            int pvCounter = 0;
            int priceCounter = 0;
            foreach (var interimResult in interimResults)
            {
                foreach (var item in interimResult)
                {
                    
                    var calculatedBookSummary = new CalculatedBookSummary
                    {
                        books = item.trading_book,
                        descriptions = item.aries_book + item.book_desc,
                        breaks = CalculateBreaks(item, pv.value.Trim(), pl.value.Trim(), breaks.value.Trim(), ref breaksCounter),
                        w_reason = CalculateWReason(item, pv.value.Trim(), pl.value.Trim(), breaks.value.Trim(), ref wreasonCounter),
                        matched = CalculateMatched(item, breaks.value.Trim(), ref matchedCounter),
                        position = item.posn_age_break != 0 ? ++positionCounter : positionCounter,
                        pandl = double.Parse(item.pandl_diff.ToString()) > double.Parse(pl.value.Trim()) ? ++pandlCounter : pandlCounter,
                        pv = double.Parse(item.pv_diff.ToString()) > double.Parse(pv.value.Trim()) ? ++pvCounter : pvCounter,
                        hugo = item.hugo_code,
                        price = CalculatePrice(breaks.value.Trim(), pv.value.Trim(), pl.value.Trim(), item, ref priceCounter)
                    };
                    results.Add(calculatedBookSummary);
                }

            }
            var summary = new CalculatedBookSummary
            {
                books = "All Books",
                descriptions = string.Empty,
                breaks = results.Sum(x => x.breaks),
                w_reason = results.Sum(x => x.w_reason),
                matched = results.Sum(x => x.matched),
                position = results.Sum(x => x.position),
                price = results.Sum(x => x.price),
                pandl = results.Sum(x => x.pandl),
                pv = results.Sum(x => x.pv),
                hugo = string.Empty
            };
            results.Insert(0, summary);
            if (pageSize == 0)
            {
                return results;
            }
            else
            {
                return results.Skip(offSet).Take(pageSize);
            }
        }

        private double CalculatePrice(string v1, string v2, string v3, dynamic item, ref int priceCounter)
        {
            if(v1 == "Y")
            {
                if(double.Parse(item.price_diff.ToString()) != 0 || double.Parse(item.pv_diff.ToString()) > double.Parse(v2.Trim()) || double.Parse(item.pandl_diff.ToString()) > double.Parse(v3.Trim()))
                {
                    return ++priceCounter;
                }
                else if(double.Parse(item.price_diff.ToString()) != 0)
                {
                    return ++priceCounter;
                }
            }

            return priceCounter;
        }

        private double CalculateMatched(dynamic item, string v, ref int matchedCounter)
        {
            if(v != "Y")
            {
                if(double.Parse(item.posn_diff.ToString()) == 0 && double.Parse(item.price_diff.ToString()) == 0 && double.Parse(item.pv_diff.ToString()) == 0 && double.Parse(item.pandl_diff.ToString()) == 0)
                {
                    return ++matchedCounter;
                }
            }

            return matchedCounter;
        }

        private double CalculateWReason(dynamic item, string v1, string v2, string braeks, ref int wreasonCounter)
        {
            var pv = double.Parse(v1);
            var pl = double.Parse(v2);
            if(braeks == "Y")
            {
                if((double.Parse(item.posn_diff.ToString()) != 0 || double.Parse(item.pv_diff.ToString()) > pv || double.Parse(item.pandl_diff.ToString()) > pl) && !string.IsNullOrEmpty(item.narrative))
                {
                    return ++wreasonCounter;
                }
                else
                {
                    if((double.Parse(item.posn_diff.ToString()) != 0 || double.Parse(item.price_diff.ToString()) != 0 || double.Parse(item.pv_diff.ToString()) != 0) && !string.IsNullOrEmpty(item.narrative))
                    {
                        return ++wreasonCounter;
                    }
                }
            }
            return wreasonCounter;
        }

        private double CalculateBreaks(dynamic item, string pv, string pl, string breaks, ref int breaksCounter)
        {
            var calculatedPv = double.Parse(pv);
            var calculatedPl = double.Parse(pl);
            if(breaks == "Y")
            {
                if(double.Parse(item.posn_diff.ToString()) != 0 || double.Parse(item.pv_diff.ToString()) > calculatedPv || double.Parse(item.pandl_diff.ToString()) > calculatedPl)
                {
                    return ++breaksCounter;
                }
                else
                {
                    if(double.Parse(item.posn_diff.ToString()) != 0 || double.Parse(item.price_diff.ToString()) != 0 || double.Parse(item.pv_diff.ToString()) != 0 || double.Parse(item.pandl_diff.ToString()) != 0)
                    {
                        return ++breaksCounter;
                    }
                }
            }
            return breaksCounter;
        }
    }
}
