using Entities.Contracts;

namespace DataAccess.Contracts
{
    public interface IPersistenceController<T> where T : AbstractEntityBase
    {
        IDataAccess<T> GetPersistenceController();
    }
}
