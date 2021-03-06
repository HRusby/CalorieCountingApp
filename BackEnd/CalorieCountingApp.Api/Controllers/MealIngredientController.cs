using System.Collections.Generic;
using CalorieCountingApp.Data.Dao;
using CalorieCountingApp.Domain;
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
            MealIngredient mealIngredient)
        {
            // Returns the Id of the new record
            return dao.AddNewMealIngredient(mealIngredient);
        }

        [HttpPost]
        [Route("UpdateMealIngredient")]
        public bool UpdateMealIngredient(MealIngredient updatedIngredient){
            return dao.UpdateMealIngredient(updatedIngredient);
        }

        [HttpPost]
        [Route("DeleteMealIngredient")]
        public bool DeleteMealIngredient([FromBody]int ingredientId){
            return dao.DeleteMealIngredient(ingredientId);
        }

        [HttpPost]
        [Route("GetMealIngredientsForMealId")]
        public List<DisplayableMealIngredient> GetMealIngredientsForMealId([FromBody]int mealId){
            return dao.GetMealIngredientsForMealId(mealId);
        }
    }
}