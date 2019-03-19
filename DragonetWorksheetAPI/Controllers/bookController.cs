using DataAccess.Impl;
using Entities.Impl;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.IO;
using System.Web.Http;
using System.Linq;

namespace DragonetWorksheetAPI.Controllers
{
    public class bookController : ApiController
    {
        [HttpGet]
        public object getBooks(string bu)
        {
            BookRepository<Book> repository = new BookRepository<Book>();
            dynamic results = repository.GetMultipleEntities(new { param = bu });
            string json = JsonConvert.SerializeObject(results);
            using (StringReader sr = new StringReader(json))
            {
                using (JsonTextReader reader = new JsonTextReader(sr))
                {
                    JToken token = new Common.Helpers.JsonHelpers().DeserializeAndCombineDuplicates(reader);
                    return token.Children();
                }
            }
        }
    }
}
