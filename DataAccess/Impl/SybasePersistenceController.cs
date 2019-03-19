using Common;
using Dapper;
using DataAccess.Contracts;
using Entities.Contracts;
using Sybase.Data.AseClient;
using System;
using System.Collections.Generic;
using System.Data;

namespace DataAccess.Impl
{
    public class SybasePersistenceController<T> : IDataAccess<T> where T : AbstractEntityBase
    {
        private readonly string connectionString;
        private readonly Lazy<AseConnection> aseConnection;

        public Lazy<AseConnection> AseConnection => aseConnection;

        public SybasePersistenceController()
        {
            connectionString = AppLevelVariables.ConnectionString;
            aseConnection = new Lazy<AseConnection>(InitializeConnection);
        }

        private AseConnection InitializeConnection()
        {
            return new AseConnection(connectionString);
        }

        public bool Create(string sql, object paramter)
        {
            return ExecuteQuery(sql, paramter);
        }

        private bool ExecuteQuery(string sql, object paramter)
        {
            using (aseConnection.Value)
            {
                try
                {
                    aseConnection.Value.Query(sql, paramter);
                    return true;
                }
                catch (Exception ex)
                {
                    return false;
                }
            }
        }

        public bool Delete(string sql, object parameter)
        {
            return ExecuteQuery(sql, parameter);
        }

        public T GetById(string sql, object parameter = null)
        {
            using (aseConnection.Value)
            {
                try
                {
                    return aseConnection.Value.QueryFirstOrDefault<T>(sql, param: parameter);
                }
                catch (Exception)
                {
                    return default(T);
                }
            }
        }

        public bool Update(string sql, object parameter)
        {
            return ExecuteQuery(sql, parameter);
        }

        public List<T> GetAllEntities(string sql, object parameter = null)
        {
            using (aseConnection.Value)
            {
                try
                {
                    List<T> result = aseConnection.Value.Query<T>(sql, param: parameter).AsList();
                    return result;
                }
                catch (Exception)
                {
                    return null;
                }
            }
        }

        public List<dynamic> ExecuteStoredProcedure(string sql, object parameter)
        {
            using (aseConnection.Value)
            {
                try
                {
                    return aseConnection.Value.Query(sql, parameter, commandType: CommandType.StoredProcedure).AsList();
                }
                catch (Exception)
                {
                    return null;
                }
            }
        }
    }
}