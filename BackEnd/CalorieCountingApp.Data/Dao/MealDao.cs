using System;
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
                cmd.Parameters.Add(new MySqlParameter("$CookedWeightMetricId", (int)meal.CookedWeightMetricId));
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
                cmd.Parameters.Add(new MySqlParameter("$CookedWeightMetricId", (int)updatedMeal.CookedWeightMetricId));
                cmd.Parameters.Add(new MySqlParameter("$RemainingWeight", updatedMeal.RemainingWeight));
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
    }
}