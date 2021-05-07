using Microsoft.AspNetCore.Mvc;
using CalorieCountingApp.Domain;
using System;
using CalorieCountingApp.Domain.Enums;

namespace CalorieCountingApp.Controllers
{
    [ApiController]
    [Route("Meal")]
    public class MealController
    {
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
            return -1;
        }

        [HttpPost]
        [Route("UpdateMeal")]
        public bool UpdateMeal(Meal updatedMeal){
            return true;
        }

        [HttpPost]
        [Route("DeleteMeal")]
        public bool DeleteMeal(int mealId){
            return true;
        }
    }
}