using Microsoft.AspNetCore.Mvc;
using CalorieCountingApp.Domain;
using System;
using System.Text.Json;
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
        public int AddNewMeal([FromBody]JsonElement data)
        {
            string name = Convert.ToString(data.GetProperty("name"));
            int userId = Convert.ToInt32(data.GetProperty("userId").ToString());
            double cookedWeight = Convert.ToDouble(data.GetProperty("cookedWeight").ToString());
            Metric cookedWeightMetricId = (Metric)Convert.ToInt32(data.GetProperty("cookedWeightMetricId").ToString());
            double remainingWeight = Convert.ToDouble(data.GetProperty("remainingWeight").ToString());
            DateTime cookedOn = Convert.ToDateTime(data.GetProperty("cookedOn").ToString());
            Console.WriteLine("Request Received Name: "+name);
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