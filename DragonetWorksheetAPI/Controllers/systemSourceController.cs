using DataAccess.Contracts;
using DataAccess.Impl;
using Entities.Impl;
using System.Collections.Generic;
using System.Web.Http;

namespace DragonetWorksheetAPI.Controllers
{
    public class systemSourceController : ApiController
    {
        [HttpGet]
        public IEnumerable<SystemSource> getSystemSources()
        {
            IRepository<SystemSource> repository = new Repository<SystemSource>();
            return repository.GetAllEntities();
        }
    }
}
