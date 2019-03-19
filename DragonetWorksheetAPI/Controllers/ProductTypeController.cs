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
    public class productTypeController : ApiController
    {
        [HttpGet]
        public IEnumerable<ProductType> getProductTypes()
        {
            IRepository<ProductType> repository = new Repository<ProductType>();
            return repository.GetAllEntities();
        }
    }
}
