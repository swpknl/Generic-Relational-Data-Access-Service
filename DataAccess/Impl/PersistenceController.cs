using DataAccess.Contracts;
using Entities.Contracts;

namespace DataAccess.Impl
{
    public class PersistenceController<T> : IPersistenceController<T> where T : AbstractEntityBase
    {
        public IDataAccess<T> GetPersistenceController()
        {
            return new SybasePersistenceController<T>();
        }
    }
}
