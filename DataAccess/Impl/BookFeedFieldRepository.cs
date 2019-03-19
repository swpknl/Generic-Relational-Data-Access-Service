using DataAccess.Contracts;
using Entities.Contracts;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using Dapper;
using System.Text;
using System.Threading.Tasks;
using Entities.Impl;

namespace DataAccess.Impl
{
    public class BookFeedFieldRepository<T> : Repository<T> where T : AbstractEntityBase
    {
        public string GetTable(string sourceName)
        {
            if (ConfigurationManager.AppSettings.AllKeys.Any(x => x.Equals(sourceName, StringComparison.OrdinalIgnoreCase)))
            {
                return ConfigurationManager.AppSettings[sourceName];
            }
            else
            {
                return string.Empty;
            }
        }

        public List<BookFeedField> GetBookFeedFields(string tableName)
        {
            var connection = (controller.GetPersistenceController() as SybasePersistenceController<T>).AseConnection.Value;
            var query = string.Format(entity.CreateGetAllEntitiesSQL(), tableName);
            var results = connection.Query(sql: query);
            var bookFeedFields = new List<BookFeedField>();
            foreach (var items in results)
            {
                foreach (var item in items)
                {
                    bookFeedFields.Add(new BookFeedField()
                    {
                        display_name = item.Key,
                        name = item.Key,
                        value = item.Value
                    });
                }
            }

            return bookFeedFields;
        }
    }
}
