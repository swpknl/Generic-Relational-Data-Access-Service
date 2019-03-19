using DataAccess.Contracts;
using DataAccess.Impl;
using Entities.Impl;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace DragonetWorksheetAPI.Controllers
{
    public class bucCriteriaLineController : ApiController
    {
        private class bucCriteriaLineParams
        {
            public string param1 { get; set; }
            public string param2 { get; set; }
            public string param3 { get; set; }
            public DateTime param4 { get; set; }
        }

        [HttpPost]
        public HttpResponseMessage createBucCriteriaLines(BUCCriteriaLineRequest bUCCriteriaLineRequest)
        {
            IRepository<BUCCriteriaLine> repository = new Repository<BUCCriteriaLine>();
            string userId = string.Format("{0}:{1}DT:{2}TM:{3}", ConfigurationManager.AppSettings["WindowName"], bUCCriteriaLineRequest.user_id, DateTime.Now.ToString("DD-Mon-yy"), DateTime.Now.Ticks);
            bool result = false;
            if(bUCCriteriaLineRequest.prod_type_ie == "I")
            {
                result = repository.Create(new bucCriteriaLineParams()
                {
                    param1 = userId,
                    param2 = "prodtypeIE",
                    param3 = "I",
                    param4 = DateTime.Now
                });
                if(!result)
                {
                    return new HttpResponseMessage(HttpStatusCode.BadRequest);
                }
            }
            else
            {
                result = repository.Create(new bucCriteriaLineParams()
                {
                    param1 = userId,
                    param2 = "prodtypeIE",
                    param3 = "E",
                    param4 = DateTime.Now
                });
                if (!result)
                {
                    return new HttpResponseMessage(HttpStatusCode.BadRequest);
                }
                result = repository.Create(new bucCriteriaLineParams()
                {
                    param1 = userId,
                    param2 = "prod_type",
                    param3 = "40",
                    param4 = DateTime.Now
                });
                if (!result)
                {
                    return new HttpResponseMessage(HttpStatusCode.BadRequest);
                }
            }
            result = repository.Create(new bucCriteriaLineParams()
            {
                param1 = userId,
                param2 = "display",
                param3 = "1111",
                param4 = DateTime.Now
            });
            if (!result)
            {
                return new HttpResponseMessage(HttpStatusCode.BadRequest);
            }
            result = repository.Create(new bucCriteriaLineParams()
            {
                param1 = userId,
                param2 = "breaks",
                param3 = bUCCriteriaLineRequest.breaks ? "Y" : "N",
                param4 = DateTime.Now
            });
            if (!result)
            {
                return new HttpResponseMessage(HttpStatusCode.BadRequest);
            }
            result = repository.Create(new bucCriteriaLineParams()
            {
                param1 = userId,
                param2 = "pl_tol",
                param3 = bUCCriteriaLineRequest.pl_tol.ToString(),
                param4 = DateTime.Now
            });
            if (!result)
            {
                return new HttpResponseMessage(HttpStatusCode.BadRequest);
            }
            result = repository.Create(new bucCriteriaLineParams()
            {
                param1 = userId,
                param2 = "pv_tol",
                param3 = bUCCriteriaLineRequest.pv_tol.ToString(),
                param4 = DateTime.Now
            });
            if (!result)
            {
                return new HttpResponseMessage(HttpStatusCode.BadRequest);
            }
            result = repository.Create(new bucCriteriaLineParams()
            {
                param1 = userId,
                param2 = "posn_dt",
                param3 = bUCCriteriaLineRequest.posn_date.ToString(),
                param4 = DateTime.Now
            });
            if (!result)
            {
                return new HttpResponseMessage(HttpStatusCode.BadRequest);
            }
            result = repository.Create(new bucCriteriaLineParams()
            {
                param1 = userId,
                param2 = "bo_source",
                param3 = bUCCriteriaLineRequest.bo_source,
                param4 = DateTime.Now
            });
            if (!result)
            {
                return new HttpResponseMessage(HttpStatusCode.BadRequest);
            }
            result = repository.Create(new bucCriteriaLineParams()
            {
                param1 = userId,
                param2 = "fo_source",
                param3 = bUCCriteriaLineRequest.fo_source,
                param4 = DateTime.Now
            });
            if (!result)
            {
                return new HttpResponseMessage(HttpStatusCode.BadRequest);
            }
            result = repository.Create(new bucCriteriaLineParams()
            {
                param1 = userId,
                param2 = "bu_name",
                param3 = bUCCriteriaLineRequest.bu_name,
                param4 = DateTime.Now
            });
            if (!result)
            {
                return new HttpResponseMessage(HttpStatusCode.BadRequest);
            }
            return new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new StringContent(userId)
            };

        }
    }
}
