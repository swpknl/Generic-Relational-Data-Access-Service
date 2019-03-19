using Entities.Contracts;
using System.Collections.Generic;
using System.Data;

namespace DataAccess.Contracts
{
    public interface IRepository<T> where T : AbstractEntityBase
    {
        T GetById(object parameter);

        bool Create(object parameter);

        bool Delete(object parameter);

        bool Update(object parameter);

        List<T> GetAllEntities(object parameter = null);

        List<dynamic> ExecuteStoredProcedure(object parameter);
    }
}
