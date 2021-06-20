using System;
using System.Collections.Generic;
using System.Data;
using BackEnd.CalorieCountingApp.Data.Dao;
using CalorieCountingApp.Domain;
using CalorieCountingApp.Domain.Enums;
using MySql.Data.MySqlClient;

namespace CalorieCountingApp.Data.Dao
{
    public class IngredientDao : ADao
    {
        public IngredientDao(string connectionString)
            : base(connectionString)
        { }

        public int AddNewIngredient(Ingredient newIngredient)
        {
            //String commandText = "CALL CalorieCounting.AddIngredient(@$Name,@$CaloriesPerMetric,@$MetricId,@$GeneratedId";
            MySqlParameter generatedId = CreateOutputParameter("$GeneratedId", MySqlDbType.Int32);
            MySqlParameter[] sqlParameters = new MySqlParameter[4]{
                new MySqlParameter("$Name", newIngredient.Name),
                new MySqlParameter("$CaloriesPerMetric", newIngredient.CaloriesPerMetric),
                new MySqlParameter("$MetricId", (int)newIngredient.MetricId),
                generatedId
            };
            MySqlHelperExtensions.ExecuteNonQuery(ConnectionString, "AddIngredient", CommandType.StoredProcedure, sqlParameters);
            //MySqlHelper.ExecuteNonQuery(ConnectionString, commandText, sqlParameters);
            return Convert.ToInt32(generatedId.Value);
        }

        public bool UpdateIngredient(Ingredient updatedIngredient)
        {
            //String commandText = "CALL CalorieCounting.UpdateIngredient(@$IngredientId,@$Name,@$CaloriesPerMetric,@$MetricId)";
            String commandText = "UpdateIngredient";
            MySqlParameter[] sqlParams = new MySqlParameter[4]{
                new MySqlParameter("$IngredientId", updatedIngredient.Id),
                new MySqlParameter("$Name", updatedIngredient.Name),
                new MySqlParameter("$CaloriesPerMetric", updatedIngredient.CaloriesPerMetric),
                new MySqlParameter("$MetricId", (int)updatedIngredient.MetricId)
            };

            return MySqlHelperExtensions.ExecuteNonQuery(ConnectionString, commandText, CommandType.StoredProcedure, sqlParams) == 1;
        }

        public bool DeleteIngredient(int ingredientId)
        {
            return MySqlHelper.ExecuteNonQuery(
                ConnectionString, 
                "DeleteIngredient", 
                new MySqlParameter("$IngredientId", ingredientId))
            == 1;
        }

        public List<Ingredient> GetIngredients()
        {
            using (MySqlDataReader rdr = MySqlHelper.ExecuteReader(ConnectionString, "GetIngredients"))
            {
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

        public Ingredient GetIngredient(int ingredientId)
        {
            String commandText = "CALL CalorieCounting.GetIngredient(@$IngredientId)";
            using (MySqlDataReader rdr = MySqlHelper.ExecuteReader(ConnectionString, commandText, new MySqlParameter("$IngredientId", ingredientId)))
            {
                while (rdr.Read())
                {
                    return new Ingredient(
                            rdr.GetInt32("Id"),
                            rdr.GetString("Name"),
                            rdr.GetDecimal("CaloriesPerMetric"),
                            (MetricId)rdr.GetInt32("MetricId")
                        );
                }
            }

            return null;
        }
    }
}