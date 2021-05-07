using Microsoft.AspNetCore.Mvc;
using CalorieCountingApp.Domain;
using CalorieCountingApp.Domain.Enums;

namespace CalorieCountingApp.Controllers
{
    [ApiController]
    [Route("Ingredient")]
    public class IngredientController
    {
        [HttpPost]
        [Route("AddNewIngredient")]
        public int AddNewIngredient(
            string name,
            decimal caloriesPerMetric,
            Metric metricId)
        {
            // Returns the Id of the new record
            return -1;
        }

        [HttpPost]
        [Route("UpdateIngredient")]
        public bool UpdateIngredient(Ingredient updatedIngredient){
            return true;
        }

        [HttpPost]
        [Route("DeleteIngredient")]
        public bool DeleteIngredient(int ingredientId){
            return true;
        }
    }
}