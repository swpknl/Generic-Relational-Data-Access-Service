namespace Entities.Contracts
{
    public interface IEntity
    {
        string CreateInsertSQL();

        string CreateUpdateSQL();

        string CreateGetSQL();

        string CreateDeleteSQL();

        string CreateGetByIdSQL();

        string CreateGetAllEntitiesSQL();

        string GetStoredProcedure();
    }
}
