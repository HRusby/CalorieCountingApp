using Microsoft.AspNetCore.Mvc;
using CalorieCountingApp.Domain;
using CalorieCountingApp.Data.Dao;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;

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
        public int AddNewMeal(Meal meal)
        {
            // Returns the Id of the new record
            return dao.AddNewMeal(meal);
        }

        [HttpPost]
        [Route("UpdateMeal")]
        public bool UpdateMeal(Meal updatedMeal){
            return dao.UpdateMeal(updatedMeal);
        }

        [HttpPost]
        [Route("DeleteMeal")]
        public bool DeleteMeal([FromBody]int mealId){
            return dao.DeleteMeal(mealId);
        }

        [HttpPost]
        [Route("GetMealsForUser")]
        public List<Meal> GetMealsForUser([FromBody]int userId){
            return dao.GetMealsForUser(userId);
        }
    }
}