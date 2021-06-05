using System;
using System.Collections.Generic;
using System.Linq;
using BackEnd.CalorieCountingApp.Domain;
using CalorieCountingApp.Data.Dao;
using CalorieCountingApp.Domain;

namespace BackEnd.CalorieCountingApp.Api.Models
{
    public class TrackingModel
    {
        private TrackingDao trackingDao;
        private IngredientDao ingredientDao;
        private MealDao mealDao;
        private MealIngredientDao mealIngredientDao;

        public TrackingModel(string connectionString){
            trackingDao = new TrackingDao(connectionString);
            ingredientDao = new IngredientDao(connectionString);
            mealDao = new MealDao(connectionString);
            mealIngredientDao = new MealIngredientDao(connectionString);
        }

        public int AddNewIndividualTrackingRecord(TrackingRecord record)
        {
            // Get Ingredient Calories
            Ingredient ing = ingredientDao.GetIngredient(record.MealOrIngredientId);
            record.Calories = Decimal.Multiply(ing.CaloriesPerMetric, new Decimal(record.Quantity));
            return trackingDao.AddTrackingRecord(record, "AddIndividualTrackingRecord");
        }

        public int AddNewMealTrackingRecord(TrackingRecord record)
        {
            // Get Meal CaloriesPerMetric
            List<DisplayableMealIngredient> ingredients = mealIngredientDao.GetMealIngredientsForMealId(record.MealOrIngredientId);
            double sum = ingredients.Sum(i=>i.Quantity);
            Meal meal = mealDao.GetMeal(record.MealOrIngredientId);
            Decimal caloriesPerMetric = Decimal.Divide(new decimal(sum), new decimal(meal.CookedWeight.Value));
            record.Calories = caloriesPerMetric;
            // Add Calories to Meal Ingredient
            // StoredProc to add all MealIngredient calories together and return with Meal Cooked Weight
            // Divide Total Calories by CookedWeight
            return trackingDao.AddTrackingRecord(record, "AddMealTrackingRecord");
        }

        public bool UpdateNewIndividualTrackingRecord(TrackingRecord record)
        {
            return trackingDao.UpdateTrackingRecord(record, "UpdateIndividualTrackingRecord");
        }

        public bool UpdateNewMealTrackingRecord(TrackingRecord record)
        {
            return trackingDao.UpdateTrackingRecord(record, "UpdateMealTrackingRecord");
        }

        public List<DisplayableTrackingRecord> GetTrackingDataForDateAndUser(TrackingDataRequest request)
        {
            return trackingDao.GetTrackingDataForDateAndUser(request);
        }

        public bool DeleteTrackingRecord(int trackingId){
            return trackingDao.DeleteTrackingRecord(trackingId);
        }
    }
}