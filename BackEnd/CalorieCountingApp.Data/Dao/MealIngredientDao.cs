using System;
using System.Collections.Generic;
using System.Data;
using BackEnd.CalorieCountingApp.Data.Dao;
using CalorieCountingApp.Domain;
using MySql.Data.MySqlClient;

namespace CalorieCountingApp.Data.Dao
{
    public class MealIngredientDao : ADao
    {
        public MealIngredientDao(string connectionString)
            : base(connectionString)
        { }

        public int AddNewMealIngredient(
            MealIngredient ingredient)
        {
            MySqlParameter generatedId = CreateOutputParameter("$GeneratedId", MySqlDbType.Int32);
            MySqlParameter[] sqlParameters = new MySqlParameter[4]{
                new MySqlParameter("$MealId", ingredient.MealId),
                new MySqlParameter("$IngredientId", ingredient.IngredientId),
                new MySqlParameter("$Quantity", ingredient.Quantity),
                generatedId
            };

            MySqlHelperExtensions.ExecuteNonQuery(ConnectionString, "AddMealIngredient", CommandType.StoredProcedure, sqlParameters);
            return Convert.ToInt32(generatedId.Value);
        }

        public bool UpdateMealIngredient(MealIngredient updatedIngredient)
        {
            MySqlParameter generatedId = CreateOutputParameter("$GeneratedId", MySqlDbType.Int32);
            MySqlParameter[] sqlParameters = new MySqlParameter[3]{
                new MySqlParameter("$MealIngredientId", updatedIngredient.Id),
                new MySqlParameter("$IngredientId", updatedIngredient.IngredientId),
                new MySqlParameter("$Quantity", updatedIngredient.Quantity)
            };

            int affectedRows = MySqlHelperExtensions.ExecuteNonQuery(ConnectionString, "UpdateMealIngredient", CommandType.StoredProcedure, sqlParameters);
            return affectedRows == 1;
        }

        public bool DeleteMealIngredient(int mealIngredientId)
        {
            MySqlParameter generatedId = CreateOutputParameter("$GeneratedId", MySqlDbType.Int32);

            int affectedRows = MySqlHelperExtensions.ExecuteNonQuery(ConnectionString, "DeleteMealIngredient", CommandType.StoredProcedure, new MySqlParameter("$MealIngredientId", mealIngredientId));
            return affectedRows == 1;
        }

        public List<DisplayableMealIngredient> GetMealIngredientsForMealId(int mealId)
        {
            String commandText = "CALL CalorieCounting.GetMealIngredientsForMealId(@$MealId)";
            using (MySqlDataReader rdr = MySqlHelper.ExecuteReader(ConnectionString, commandText, new MySqlParameter("$MealId", mealId)))
            {
                List<DisplayableMealIngredient> mealIngredients = new List<DisplayableMealIngredient>();
                while (rdr.Read())
                {
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