using System;
using System.Data;
using MySql.Data.MySqlClient;

namespace CalorieCountingApp.Data.Dao
{
    public class UserDao : ADao
    {
        public UserDao(string connectionString) 
            : base(connectionString)
        {}  

        public int AddNewUser(string userName, string encodedPassword)
        {
            using (MySqlCommand cmd = new MySqlCommand("AddUser", Connection))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                MySqlParameter generatedId = CreateOutputParameter("$GeneratedId", MySqlDbType.Int32);
                cmd.Parameters.Add(new MySqlParameter("$UserName", userName));
                cmd.Parameters.Add(new MySqlParameter("$EncodedPassword", userName));
                cmd.Parameters.Add(generatedId);
                cmd.ExecuteNonQuery();
                return Convert.ToInt32(generatedId.Value);
            }
        }

        public bool CheckLogin(string userName, string encodedPassword)
        {
            using (MySqlCommand cmd = new MySqlCommand("CheckLogin", Connection))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                MySqlParameter isValidLogin = CreateOutputParameter("$ValidLogin", MySqlDbType.Int32);
                cmd.Parameters.Add(new MySqlParameter("$UserName", userName));
                cmd.Parameters.Add(new MySqlParameter("$EncodedPassword", userName));
                cmd.Parameters.Add(isValidLogin);
                cmd.ExecuteNonQuery();
                return Convert.ToBoolean(isValidLogin.Value);
            }
        }
    }
}