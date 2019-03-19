using Entities.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;

namespace DataAccess.Impl
{
    public class BookProductRepository<T> : Repository<T> where T : AbstractEntityBase
    {
        public IEnumerable<dynamic> GetProductInfo(object parameters)
        {
            var sybasePersistenceController = controller.GetPersistenceController() as SybasePersistenceController<T>;
            return sybasePersistenceController.AseConnection.Value.Query(entity.CreateGetAllEntitiesSQL(), param: parameters);
        }
    }
}
