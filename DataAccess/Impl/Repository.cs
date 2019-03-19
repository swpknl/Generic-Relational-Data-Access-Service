using DataAccess.Contracts;
using Entities.Contracts;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace DataAccess.Impl
{
    public class Repository<T> : IRepository<T> where T : AbstractEntityBase
    {
        protected readonly IPersistenceController<T> controller = new PersistenceController<T>();
        protected readonly T entity;

        public Repository()
        {
            entity = (T)Activator.CreateInstance(typeof(T));
        }

        public virtual bool Create(object parameter)
        {
            return controller.GetPersistenceController().Create(entity.CreateInsertSQL(), parameter);
        }

        public virtual bool Delete(object parameter)
        {
            return controller.GetPersistenceController().Delete(entity.CreateDeleteSQL(), parameter);
        }

        public virtual List<T> GetAllEntities(object parameter)
        {   
            return controller.GetPersistenceController().GetAllEntities(entity.CreateGetAllEntitiesSQL(), parameter);
        }

        public virtual T GetById(object parameter)
        {   
            return controller.GetPersistenceController().GetById(entity.CreateGetByIdSQL(),parameter);
        }

        public virtual bool Update(object parameter)
        {
            return controller.GetPersistenceController().Update(entity.CreateUpdateSQL(),parameter);
        }

        public virtual List<dynamic> ExecuteStoredProcedure(object parameter)
        {
            return controller.GetPersistenceController().ExecuteStoredProcedure(entity.GetStoredProcedure(), parameter);
        }
    }
}
