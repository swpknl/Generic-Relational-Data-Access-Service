using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities.Contracts;
using Entities.Impl;
using Dapper;

namespace DataAccess.Impl
{
    public class BookRepository<T> where T : AbstractEntityBase
    {
        public dynamic GetMultipleEntities(object parameter)
        {
            var controller = new PersistenceController<T>().GetPersistenceController() as SybasePersistenceController<T>;
            Book book = new Book();
            var results = controller.AseConnection.Value.QueryMultiple(book.CreateGetAllEntitiesSQL(), param: parameter).Read();
            return results;
        }
    }
}
