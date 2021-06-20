using System;
using System.Collections.Generic;
using System.Data;
using BackEnd.CalorieCountingApp.Data.Dao;
using CalorieCountingApp.Domain;
using CalorieCountingApp.Domain.Enums;
using MySql.Data.MySqlClient;

namespace CalorieCountingApp.Data.Dao
{
    public class MealDao : ADao
    {
        public MealDao(string connectionString)
            : base(connectionString)
        { }

        public int AddNewMeal(Meal meal)
        {
            MySqlParameter generatedId = CreateOutputParameter("$GeneratedId", MySqlDbType.Int32);
            MySqlParameter[] sqlParameters = new MySqlParameter[6]{
                new MySqlParameter("$Name", meal.Name),
                new MySqlParameter("$UserId", meal.UserId),
                new MySqlParameter("$CookedWeight", meal.CookedWeight),
                new MySqlParameter("$CookedWeightMetricId", meal.CookedWeightMetricId.HasValue ? (int)meal.CookedWeightMetricId : null),
                new MySqlParameter("$CookedOn", meal.CookedOn),
                generatedId
            };

            MySqlHelperExtensions.ExecuteNonQuery(ConnectionString, "AddMeal", CommandType.StoredProcedure, sqlParameters);
            return Convert.ToInt32(generatedId.Value);
        }

        public bool UpdateMeal(Meal updatedMeal)
        {
            MySqlParameter[] sqlParameters = new MySqlParameter[6]{
                new MySqlParameter("$MealId", updatedMeal.Id),
                new MySqlParameter("$Name", updatedMeal.Name),
                new MySqlParameter("$CookedWeight", updatedMeal.CookedWeight),
                new MySqlParameter("$CookedWeightMetricId", updatedMeal.CookedWeightMetricId.HasValue ? (int)updatedMeal.CookedWeightMetricId : null),
                new MySqlParameter("$RemainingWeight", updatedMeal.RemainingWeight),
                new MySqlParameter("$CookedOn", updatedMeal.CookedOn)
            };

            int affectedRows = MySqlHelperExtensions.ExecuteNonQuery(ConnectionString, "UpdateMeal", CommandType.StoredProcedure, sqlParameters);
            return affectedRows == 1;
        }

        public bool DeleteMeal(int mealId)
        {
            int affectedRows = MySqlHelperExtensions.ExecuteNonQuery(
                ConnectionString,
                "DeleteMeal",
                CommandType.StoredProcedure,
                new MySqlParameter("$MealId", mealId));
            return affectedRows == 1;
        }

        public List<Meal> GetMealsForUser(int userId)
        {
            String commandText = "CALL CalorieCounting.GetMealsForUser(@$UserId)";
            using (MySqlDataReader rdr = MySqlHelper.ExecuteReader(ConnectionString, commandText, new MySqlParameter("$UserId", userId)))
            {
                List<Meal> meals = new List<Meal>();
                while (rdr.Read())
                {
                    // Create Meal
                    Meal meal = new Meal(
                        rdr.GetInt32("Id"),
                        rdr.GetString("Name"),
                        rdr.GetInt32("UserId"),
                        rdr["CookedWeight"].DbCast<double>(),
                        (MetricId?)rdr["CookedWeightMetricId"].DbCast<int>(),
                        rdr["RemainingWeight"].DbCast<double>(),
                        rdr.GetDateTime("CookedOn")
                    );
                    meals.Add(meal);
                }
                return meals;
            }
        }

        public Meal GetMeal(int mealId)
        {
            String commandText = "CALL CalorieCounting.GetMeal(@$MealId)";
            using (MySqlDataReader rdr = MySqlHelper.ExecuteReader(ConnectionString, commandText, new MySqlParameter("$MealId", mealId)))
            {
                while (rdr.Read())
                {
                    return new Meal(
                        rdr.GetInt32("Id"),
                        rdr.GetString("Name"),
                        rdr.GetInt32("UserId"),
                        rdr["CookedWeight"].DbCast<double>(),
                        (MetricId?)rdr["CookedWeightMetricId"].DbCast<int>(),
                        rdr["RemainingWeight"].DbCast<double>(),
                        rdr.GetDateTime("CookedOn")
                    );
                }
                return null;
            }
        }
    }
}