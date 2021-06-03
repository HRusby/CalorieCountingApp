using BackEnd.CalorieCountingApp.Data.Dao;
using CalorieCountingApp.Domain;
using CalorieCountingApp.Domain.Enums;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace BackEnd.CalorieCountingApp.Api.Controllers
{
    [ApiController]
    [Route("MealIngredient")]
    public class MealIngredientController
    {
        private readonly MealIngredientDao dao;

         public MealIngredientController(IConfiguration configuration)
        {
            string connString = configuration.GetValue<string>("ConnectionStrings:CalorieCounting");
            dao = new MealIngredientDao(connString);
        }

        [HttpPost]
        [Route("AddNewMealIngredient")]
        public int AddNewMealIngredient(
            int mealId,
            int ingredientId,
            MetricId metricId,
            double quantity)
        {
            // Returns the Id of the new record
            return dao.AddNewMealIngredient(
                    mealId,
                    ingredientId,
                    metricId,
                    quantity);
        }

        [HttpPost]
        [Route("UpdateMealIngredient")]
        public bool UpdateMealIngredient(MealIngredient updatedIngredient){
            return dao.UpdateMealIngredient(updatedIngredient);
        }

        [HttpPost]
        [Route("DeleteMealIngredient")]
        public bool DeleteMealIngredient(int ingredientId){
            return dao.DeleteMealIngredient(ingredientId);
        }
    }
}