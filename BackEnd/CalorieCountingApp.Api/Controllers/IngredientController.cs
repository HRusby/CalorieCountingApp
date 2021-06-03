using Microsoft.AspNetCore.Mvc;
using CalorieCountingApp.Domain;
using CalorieCountingApp.Domain.Enums;
using CalorieCountingApp.Data.Dao;
using Microsoft.Extensions.Configuration;

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
        public int AddNewIngredient(
            string name,
            decimal caloriesPerMetric,
            MetricId metricId)
        {
            return dao.AddNewIngredient(
                name,
                caloriesPerMetric,
                metricId);
        }

        [HttpPost]
        [Route("UpdateIngredient")]
        public bool UpdateIngredient(Ingredient updatedIngredient){
            return dao.UpdateIngredient(updatedIngredient);
        }

        [HttpPost]
        [Route("DeleteIngredient")]
        public bool DeleteIngredient(int ingredientId){
            return dao.DeleteIngredient(ingredientId);
        }
    }
}