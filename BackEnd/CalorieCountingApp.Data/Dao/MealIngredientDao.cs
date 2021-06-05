using System;
using System.Collections.Generic;
using System.Data;
using CalorieCountingApp.Domain;
using MySql.Data.MySqlClient;

namespace CalorieCountingApp.Data.Dao
{
    public class MealIngredientDao : ADao
    {
        public MealIngredientDao(string connectionString) 
            : base(connectionString)
        {}

        public int AddNewMealIngredient(
            MealIngredient ingredient)
        {
            using (MySqlCommand cmd = new MySqlCommand("AddMealIngredient", Connection))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                MySqlParameter generatedId = CreateOutputParameter("$GeneratedId", MySqlDbType.Int32);
                cmd.Parameters.Add(new MySqlParameter("$MealId", ingredient.MealId));
                cmd.Parameters.Add(new MySqlParameter("$IngredientId", ingredient.IngredientId));
                cmd.Parameters.Add(new MySqlParameter("$Quantity", ingredient.Quantity));
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

        public List<DisplayableMealIngredient> GetMealIngredientsForMealId(int mealId){
            using(MySqlCommand cmd = new MySqlCommand("GetMealIngredientsForMealId", Connection)){
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new MySqlParameter("$MealId", mealId));
                MySqlDataReader rdr = cmd.ExecuteReader();

                List<DisplayableMealIngredient> mealIngredients = new List<DisplayableMealIngredient>();
                while(rdr.Read()){
                    // Create MealIngredient
                    DisplayableMealIngredient meal = new DisplayableMealIngredient(
                        rdr.GetInt32("Id"),
                        rdr.GetInt32("MealId"),
                        rdr.GetString("IngredientName"),
                        rdr.GetDouble("Quantity")
                    );
                    mealIngredients.Add(meal);
                }
                return mealIngredients;
            }
        }
    }
}