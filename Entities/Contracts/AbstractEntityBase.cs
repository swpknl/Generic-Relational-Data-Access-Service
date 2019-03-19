namespace Entities.Contracts
{
    public abstract class AbstractEntityBase : IEntity
    {
        public virtual string CreateInsertSQL()
        {
            return string.Empty;
        }

        public virtual string CreateUpdateSQL()
        {
            return string.Empty;
        }

        public virtual string CreateGetSQL()
        {
            return string.Empty;
        }

        public virtual string CreateDeleteSQL()
        {
            return string.Empty;
        }

        public virtual string CreateGetAllEntitiesSQL()
        {
            return string.Empty;
        }

        public virtual string CreateGetByIdSQL()
        {
            return string.Empty;
        }

        public virtual string GetStoredProcedure()
        {
            return string.Empty;
        }
    }
}
