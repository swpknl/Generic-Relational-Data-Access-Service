using DataAccess.Contracts;
using DataAccess.Impl;
using Entities.Impl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Http;

namespace DragonetWorksheetAPI.Controllers
{
    public class breakReasonController : ApiController
    {
        [HttpGet]
        public IEnumerable<BreakReason> getBreakReasons()
        {
            IRepository<BreakReason> repository = new Repository<BreakReason>();
            return repository.GetAllEntities();
        }

        [HttpPost]
        public HttpResponseMessage createBreakReason(BreakReason breakReason)
        {
            IRepository<BreakReason> repository = new Repository<BreakReason>();
            if (repository.Create(new { param1 = breakReason.reason_code, param2 = breakReason.description, param3 = breakReason.last_upd_by, param4 = DateTime.Now }))
            {
                return new HttpResponseMessage(System.Net.HttpStatusCode.OK);
            }
            else
            {
                return new HttpResponseMessage(System.Net.HttpStatusCode.BadRequest);
            }
        }

        [HttpPut]
        public HttpResponseMessage updateBreakReason(BreakReason breakReason)
        {
            IRepository<BreakReason> repository = new Repository<BreakReason>();
            var currentBreakReason = repository.GetById(new { param1 = breakReason.reason_code });
            if(currentBreakReason == null)
            {
                return new HttpResponseMessage(System.Net.HttpStatusCode.NotFound);
            }
            else
            {
                if (repository.Update(new { param1 = breakReason.description, param2 = breakReason.last_upd_by, param3 = breakReason.last_upd_dt, param4 = breakReason.reason_code }))
                {
                    return new HttpResponseMessage(System.Net.HttpStatusCode.OK);
                }
                else
                {
                    return new HttpResponseMessage(System.Net.HttpStatusCode.BadRequest);
                }
            }
        }

        [HttpDelete]
        public HttpResponseMessage deleteBreakReason(string reasonCode)
        {
            IRepository<BreakReason> repository = new Repository<BreakReason>();
            var currentBreakReason = repository.GetById(new { param1 = reasonCode });
            if(currentBreakReason == null)
            {
                return new HttpResponseMessage(System.Net.HttpStatusCode.NotFound);
            }
            else
            {
                if (repository.Delete(new { param1 = reasonCode }))
                {
                    return new HttpResponseMessage(System.Net.HttpStatusCode.OK);
                }
                else
                {
                    return new HttpResponseMessage(System.Net.HttpStatusCode.NotFound);
                }
            }
        }
    }
}