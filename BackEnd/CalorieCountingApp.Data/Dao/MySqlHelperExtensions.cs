using System.Data;
using MySql.Data.MySqlClient;

namespace BackEnd.CalorieCountingApp.Data.Dao
{
    // Extensions Needed to call SQL using CommandType StoredProcedure, Not possible in MySql.Data.MySqlClient.MySqlHelper version
    public static class MySqlHelperExtensions
    {
        public static int ExecuteNonQuery(
            MySqlConnection connection, 
            string commandText, 
            CommandType cmdType, 
            params MySqlParameter[] commandParameters)
        {
            //create a command and prepare it for execution
            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = connection;
            cmd.CommandText = commandText;
            cmd.CommandType = cmdType;

            if (commandParameters != null)
                foreach (MySqlParameter p in commandParameters)
                    cmd.Parameters.Add(p);

            int result = cmd.ExecuteNonQuery();
            cmd.Parameters.Clear();

            return result;
        }

        public static int ExecuteNonQuery(
            string connectionString, 
            string commandText, 
            CommandType cmdType, 
            params MySqlParameter[] commandParameters)
        {
            using (MySqlConnection cn = new MySqlConnection(connectionString))
            {
                cn.Open();

                //call the overload that takes a connection in place of the connection string
                return ExecuteNonQuery(cn, commandText, cmdType, commandParameters);
            }
        }
    }
}