using Microsoft.AspNetCore.Mvc;
using CalorieCountingApp.Domain;
using CalorieCountingApp.Domain.Enums;
using CalorieCountingApp.Data.Dao;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;

namespace CalorieCountingApp.Controllers
{
    [ApiController]
    [Route("Ingredient")]
    public class IngredientController
    {
        private readonly IngredientDao dao;

        public IngredientController(IConfiguration configuration)
        {
            string connString = configuration.GetValue<string>("ConnectionStrings:CalorieCounting");
            dao = new IngredientDao(connString);
        }

        [HttpPost]
        [Route("AddNewIngredient")]
        public int AddNewIngredient(Ingredient newIngredient)
        {
            return dao.AddNewIngredient(newIngredient);
        }

        [HttpPost]
        [Route("UpdateIngredient")]
        public bool UpdateIngredient(Ingredient updatedIngredient){
            return dao.UpdateIngredient(updatedIngredient);
        }

        [HttpPost]
        [Route("DeleteIngredient")]
        public bool DeleteIngredient([FromBody]int ingredientId){
            return dao.DeleteIngredient(ingredientId);
        }

        [HttpPost]
        [Route("GetIngredients")]
        public List<Ingredient> GetIngredients(){
            return dao.GetIngredients();
        }
    }
}