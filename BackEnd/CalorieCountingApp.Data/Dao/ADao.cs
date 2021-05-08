using System;
using System.Data;
using MySql.Data.MySqlClient;

namespace CalorieCountingApp.Data.Dao
{
    public abstract class ADao : IDisposable
    {
        protected MySqlConnection Connection {get;private set;}
        public ADao(string connectionString)
        {
            Connection = new MySqlConnection(connectionString);
            Connection.Open();
        }

        public void Dispose()
        {
            Connection.Close();
        }

        internal MySqlParameter CreateOutputParameter(string paramName, MySqlDbType paramType)
        {
            MySqlParameter outputParam = new MySqlParameter(paramName, paramType);
            outputParam.Direction = ParameterDirection.Output;
            
            return outputParam;
        }
    }
}