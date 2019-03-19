using Entities.Contracts;
using System.Collections.Generic;
using System.Data;

namespace DataAccess.Contracts
{
    public interface IDataAccess<T> where T : AbstractEntityBase
    {
        T GetById(string sql, object parameter = null);

        bool Create(string sql, object parameter);

        bool Delete(string sql, object parameter);

        bool Update(string sql, object parameter);

        List<T> GetAllEntities(string sql, object parameter = null);

        List<dynamic> ExecuteStoredProcedure(string sql, object parameter);
    }
}
