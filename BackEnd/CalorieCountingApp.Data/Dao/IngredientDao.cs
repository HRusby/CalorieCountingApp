using System;
using System.Collections.Generic;
using System.Data;
using CalorieCountingApp.Domain;
using CalorieCountingApp.Domain.Enums;
using MySql.Data.MySqlClient;

namespace CalorieCountingApp.Data.Dao
{
    public class IngredientDao : ADao
    {
        public IngredientDao(string connectionString) 
            : base(connectionString)
        {}

        public int AddNewIngredient(
            string name,
            decimal caloriesPerMetric,
            MetricId metricId)
        {
            using (MySqlCommand cmd = new MySqlCommand("AddIngredient", Connection))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                MySqlParameter generatedId = CreateOutputParameter("$GeneratedId", MySqlDbType.Int32);
                cmd.Parameters.Add(new MySqlParameter("$Name", name));
                cmd.Parameters.Add(new MySqlParameter("$CaloriesPerMetric", caloriesPerMetric));
                cmd.Parameters.Add(new MySqlParameter("$MetricId", (int)metricId));
                cmd.Parameters.Add(generatedId);
                cmd.ExecuteNonQuery();
                return Convert.ToInt32(generatedId.Value);
            }
        }

        public bool UpdateIngredient(Ingredient updatedIngredient){
            using (MySqlCommand cmd = new MySqlCommand("UpdateIngredient", Connection))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new MySqlParameter("$IngredientId", updatedIngredient.Id));
                cmd.Parameters.Add(new MySqlParameter("$Name", updatedIngredient.Name));
                cmd.Parameters.Add(new MySqlParameter("$CaloriesPerMetric", updatedIngredient.CaloriesPerMetric));
                cmd.Parameters.Add(new MySqlParameter("$MetricId", (int)updatedIngredient.MetricId));
                int affectedRows = cmd.ExecuteNonQuery();
                return affectedRows == 1;
            }
        }

        public bool DeleteIngredient(int ingredientId)
        {
            using (MySqlCommand cmd = new MySqlCommand("DeleteIngredient", Connection))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new MySqlParameter("$IngredientId", ingredientId));
                int affectedRows = cmd.ExecuteNonQuery();
                return affectedRows == 1;
            }
        }

        public List<Ingredient> GetIngredients()
        {
            using (MySqlCommand cmd = new MySqlCommand("GetIngredients", Connection))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                MySqlDataReader rdr = cmd.ExecuteReader();

                List<Ingredient> ingredients = new List<Ingredient>();
                while (rdr.Read())
                {
                    // Create Ingredient
                    Ingredient ingredient = new Ingredient(
                        rdr.GetInt32("Id"),
                        rdr.GetString("Name"),
                        rdr.GetDecimal("CaloriesPerMetric"),
                        (MetricId)rdr.GetInt32("MetricId")                        
                    );
                    
                    ingredients.Add(ingredient);
                }

                return ingredients;
            }
        }
    }
}