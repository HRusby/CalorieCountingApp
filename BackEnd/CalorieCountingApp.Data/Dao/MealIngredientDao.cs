using System;
using System.Collections.Generic;
using System.Data;
using CalorieCountingApp.Data.Dao;
using CalorieCountingApp.Domain;
using CalorieCountingApp.Domain.Enums;
using MySql.Data.MySqlClient;

namespace BackEnd.CalorieCountingApp.Data.Dao
{
    public class MealIngredientDao : ADao
    {
        public MealIngredientDao(string connectionString) 
            : base(connectionString)
        {}

        public int AddNewMealIngredient(
            int mealId,
            int ingredientId,
            MetricId metricId,
            double quantity)
        {
            using (MySqlCommand cmd = new MySqlCommand("AddMealIngredient", Connection))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                MySqlParameter generatedId = CreateOutputParameter("$GeneratedId", MySqlDbType.Int32);
                cmd.Parameters.Add(new MySqlParameter("$MealId", mealId));
                cmd.Parameters.Add(new MySqlParameter("$IngredientId", ingredientId));
                cmd.Parameters.Add(new MySqlParameter("$MetricId", (int)metricId));
                cmd.Parameters.Add(new MySqlParameter("$Quantity", quantity));
                cmd.Parameters.Add(generatedId);
                cmd.ExecuteNonQuery();
                return Convert.ToInt32(generatedId.Value);
            }
        }

        public bool UpdateMealIngredient(MealIngredient updatedIngredient){
            using (MySqlCommand cmd = new MySqlCommand("UpdateMealIngredient", Connection))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new MySqlParameter("$MealIngredientId", updatedIngredient.Id));
                cmd.Parameters.Add(new MySqlParameter("$IngredientId", updatedIngredient.IngredientId));
                cmd.Parameters.Add(new MySqlParameter("$MetricId", (int)updatedIngredient.MetricId));
                cmd.Parameters.Add(new MySqlParameter("$Quantity", updatedIngredient.Quantity));
                int affectedRows = cmd.ExecuteNonQuery();
                return affectedRows == 1;
            }
        }

        public bool DeleteMealIngredient(int mealIngredientId)
        {
            using (MySqlCommand cmd = new MySqlCommand("DeleteMealIngredient", Connection))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new MySqlParameter("$MealIngredientId", mealIngredientId));
                int affectedRows = cmd.ExecuteNonQuery();
                return affectedRows == 1;
            }
        }

        public List<MealIngredient> GetMealIngredientsForMealId(int mealId){
            using(MySqlCommand cmd = new MySqlCommand("GetMealIngredientsForMealId", Connection)){
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new MySqlParameter("$MealId", mealId));
                MySqlDataReader rdr = cmd.ExecuteReader();

                List<MealIngredient> mealIngredients = new List<MealIngredient>();
                while(rdr.Read()){
                    // Create MealIngredient
                    MealIngredient meal = new MealIngredient(
                        rdr.GetInt32("Id"),
                        rdr.GetInt32("MealId"),
                        rdr.GetInt32("IngredientId"),
                        (MetricId)rdr.GetInt32("MetricId"),
                        rdr.GetDouble("Quantity")
                    );
                    mealIngredients.Add(meal);
                }
                return mealIngredients;
            }
        }
    }
}