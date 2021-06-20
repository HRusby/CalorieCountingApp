using System;
using System.Data;
using BackEnd.CalorieCountingApp.Data.Dao;
using MySql.Data.MySqlClient;

namespace CalorieCountingApp.Data.Dao
{
    public class UserDao : ADao
    {
        public UserDao(string connectionString)
            : base(connectionString)
        { }

        public int AddNewUser(string userName, string encodedPassword)
        {
            MySqlParameter generatedId = CreateOutputParameter("$GeneratedId", MySqlDbType.Int32);
            MySqlParameter[] sqlParameters = new MySqlParameter[3]{
                new MySqlParameter("$UserName", userName),
                new MySqlParameter("$EncodedPassword", "NotImplemented"),
                generatedId
            };

            MySqlHelperExtensions.ExecuteNonQuery(ConnectionString, "AddUser", CommandType.StoredProcedure, sqlParameters);
            return Convert.ToInt32(generatedId.Value);
        }

        public bool CheckLogin(string userName, string encodedPassword)
        {
            MySqlParameter isValidLogin = CreateOutputParameter("$ValidLogin", MySqlDbType.Int32);
            MySqlParameter[] sqlParameters = new MySqlParameter[3]{
                new MySqlParameter("$UserName", userName),
                new MySqlParameter("$EncodedPassword", "NotImplemented"),
                isValidLogin
            };

            MySqlHelperExtensions.ExecuteNonQuery(ConnectionString, "CheckLogin", CommandType.StoredProcedure, sqlParameters);
            return Convert.ToBoolean(isValidLogin.Value);
        }
    }
}