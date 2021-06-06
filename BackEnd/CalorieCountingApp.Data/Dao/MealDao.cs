using System;
using System.Collections.Generic;
using System.Data;
using CalorieCountingApp.Domain;
using CalorieCountingApp.Domain.Enums;
using MySql.Data.MySqlClient;

namespace CalorieCountingApp.Data.Dao
{
    public class MealDao : ADao
    {
        public MealDao(string connectionString) 
            : base(connectionString)
        {}

        public int AddNewMeal(Meal meal)
        {
            using (MySqlCommand cmd = new MySqlCommand("AddMeal", Connection))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                MySqlParameter generatedId = CreateOutputParameter("$GeneratedId", MySqlDbType.Int32);
                cmd.Parameters.Add(new MySqlParameter("$Name", meal.Name));
                cmd.Parameters.Add(new MySqlParameter("$UserId", meal.UserId));
                cmd.Parameters.Add(new MySqlParameter("$CookedWeight", meal.CookedWeight));
                cmd.Parameters.Add(new MySqlParameter("$CookedWeightMetricId", meal.CookedWeightMetricId.HasValue ? (int)meal.CookedWeightMetricId : null));
                cmd.Parameters.Add(new MySqlParameter("$CookedOn", meal.CookedOn));
                cmd.Parameters.Add(generatedId);
                cmd.ExecuteNonQuery();
                return Convert.ToInt32(generatedId.Value);
            }
        }

        public bool UpdateMeal(Meal updatedMeal){
            using (MySqlCommand cmd = new MySqlCommand("UpdateMeal", Connection))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new MySqlParameter("$MealId", updatedMeal.Id));
                cmd.Parameters.Add(new MySqlParameter("$Name", updatedMeal.Name));
                cmd.Parameters.Add(new MySqlParameter("$CookedWeight", updatedMeal.CookedWeight));
                cmd.Parameters.Add(new MySqlParameter("$CookedWeightMetricId", updatedMeal.CookedWeightMetricId.HasValue ? (int)updatedMeal.CookedWeightMetricId : null));
                cmd.Parameters.Add(new MySqlParameter("$RemainingWeight", updatedMeal.RemainingWeight));
                cmd.Parameters.Add(new MySqlParameter("$CookedOn", updatedMeal.CookedOn));
                int affectedRows = cmd.ExecuteNonQuery();
                return affectedRows == 1;
            }
        }

        public bool DeleteMeal(int mealId)
        {
            using (MySqlCommand cmd = new MySqlCommand("DeleteMeal", Connection))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new MySqlParameter("$MealId", mealId));
                int affectedRows = cmd.ExecuteNonQuery();
                return affectedRows == 1;
            }
        }

        public List<Meal> GetMealsForUser(int userId){
            using(MySqlCommand cmd = new MySqlCommand("GetMealsForUser", Connection)){
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new MySqlParameter("$UserId", userId));
                MySqlDataReader rdr = cmd.ExecuteReader();

                List<Meal> meals = new List<Meal>();
                while(rdr.Read()){
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
            using(MySqlCommand cmd = new MySqlCommand("GetMeal", Connection)){
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new MySqlParameter("$MealId", mealId));
                MySqlDataReader rdr = cmd.ExecuteReader();
                while(rdr.Read()){
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