using Microsoft.AspNetCore.Mvc;
using CalorieCountingApp.Domain;
using System;
using CalorieCountingApp.Domain.Enums;
using CalorieCountingApp.Data.Dao;
using Microsoft.Extensions.Configuration;

namespace CalorieCountingApp.Controllers
{
    [ApiController]
    [Route("Meal")]
    public class MealController
    {

        private readonly MealDao dao;

        public MealController(IConfiguration configuration)
        {
            string connString = configuration.GetValue<string>("ConnectionStrings:CalorieCounting");
            dao = new MealDao(connString);
        }

        [HttpPost]
        [Route("AddNewMeal")]
        public int AddNewMeal(
            string name,
            int userId,
            double cookedWeight,
            Metric cookedWeightMetricId,
            double remainingWeight,
            DateTime cookedOn)
        {
            // Returns the Id of the new record
            return dao.AddNewMeal(
                    name,
                    userId,
                    cookedWeight,
                    cookedWeightMetricId,
                    remainingWeight,
                    cookedOn);
        }

        [HttpPost]
        [Route("UpdateMeal")]
        public bool UpdateMeal(Meal updatedMeal){
            return dao.UpdateMeal(updatedMeal);
        }

        [HttpPost]
        [Route("DeleteMeal")]
        public bool DeleteMeal(int mealId){
            return dao.DeleteMeal(mealId);
        }
    }
}