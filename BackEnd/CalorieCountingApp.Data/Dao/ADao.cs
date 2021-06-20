using System;
using System.Data;
using MySql.Data.MySqlClient;

namespace CalorieCountingApp.Data.Dao
{
    public abstract class ADao
    {
        protected String ConnectionString { get; private set; }
        public ADao(string connectionString)
        {
            ConnectionString = connectionString;
        }

        internal MySqlParameter CreateOutputParameter(string paramName, MySqlDbType paramType)
        {
            MySqlParameter outputParam = new MySqlParameter(paramName, paramType);
            outputParam.Direction = ParameterDirection.Output;

            return outputParam;
        }
    }
}