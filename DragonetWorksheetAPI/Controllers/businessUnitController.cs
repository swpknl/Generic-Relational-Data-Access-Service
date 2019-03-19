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
    public class businessUnitController : ApiController
    {
        [HttpGet]
        public IEnumerable<BusinessUnit> getBusinessUnits(string buTypeCd)
        {
            IRepository<BusinessUnit> repository = new Repository<BusinessUnit>();
            return repository.GetAllEntities(new { param = buTypeCd });
        }
    }
}
