using DataAccess.Contracts;
using DataAccess.Impl;
using Entities.Impl;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace DragonetWorksheetAPI.Controllers
{
    public class bookDetailController : ApiController
    {
        [HttpGet]
        public IEnumerable<object> getBookDetail(string uid, int pageSize, int offset)
        {
            IRepository<BookDetail> repository = new Repository<BookDetail>();
            var results = repository.ExecuteStoredProcedure(new { user_id = uid });
            if (pageSize == 0)
            {
                return results;
            }
            else
            {
                return results.Skip(offset).Take(pageSize);
            }
        }

        [HttpPut]
        public HttpResponseMessage updateBookDetail(RecPosnRequest recPosnRequest)
        {
            IRepository<BookDetail> repository = new Repository<BookDetail>();
            var currentRepository = repository.GetById(new { param1 = recPosnRequest.dt_loaded, param2 = recPosnRequest.rec_source, param3 = recPosnRequest.centre, param4 = recPosnRequest.hugo_code});
            if(currentRepository == null)
            {
                return new HttpResponseMessage(HttpStatusCode.NotFound);
            }
            else
            {
                var updated = repository.Update(new { param1 = recPosnRequest.description, param2 = recPosnRequest.last_upd_by, param3 = recPosnRequest.last_update_dt, param4 = recPosnRequest.dt_loaded, param5 = recPosnRequest.rec_source, param6 = recPosnRequest.centre, param7 = recPosnRequest.hugo_code });
                if(updated)
                {
                    return new HttpResponseMessage(HttpStatusCode.OK);
                }
                else
                {
                    return new HttpResponseMessage(HttpStatusCode.BadRequest);
                }
            }
;        }

        [HttpPost]
        [Route("api/v1/bookDetail/ageingAndFeeds")]
        public IDictionary<string, object> getAgeingAndFeeds(BookDetail bookDetail)
        {
            IDictionary<string, object> map = new Dictionary<string, object>();
            IRepository<Ageing> ageingRepository = new Repository<Ageing>();
            var ageingResults = ageingRepository.GetAllEntities(new { param1 = bookDetail.dt_loaded, param2 = bookDetail.trading_book, param3 = bookDetail.hugo_code, param4 = bookDetail.rec_source });
            map.Add("ageing", ageingResults);
            var bookFeedFieldRepository = new BookFeedFieldRepository<BookFeedField>();
            var table = bookFeedFieldRepository.GetTable(bookDetail.bo_source);
            var boSourceBookFeedField = bookFeedFieldRepository.GetBookFeedFields(table);
            table = bookFeedFieldRepository.GetTable(bookDetail.fo_source);
            var foSourceBookFeedField = bookFeedFieldRepository.GetBookFeedFields(table);
            var bookFeedFields = boSourceBookFeedField.Union(foSourceBookFeedField);
            var feeds = new Feeds()
            {
                rows = bookFeedFields.ToList()
            };
            map.Add("feeds", feeds);
            var parameters = new { param1 = bookDetail.dt_loaded, param2 = bookDetail.trading_book, param3 = bookDetail.prod_code };
            BookProductRepository<BookProduct> bookProductRepository = new BookProductRepository<BookProduct>();
            var productInfo = bookProductRepository.GetProductInfo(parameters);
            map.Add("product_info", productInfo);
            return map;
        }
    }
}
