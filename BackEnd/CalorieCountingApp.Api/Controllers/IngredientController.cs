using Microsoft.AspNetCore.Mvc;

namespace BackEnd.Controllers
{
    [ApiController]
    [Route("Ingredient")]
    public class IngredientController
    {
        [HttpPost]
        [Route("AddNewIngredient")]
        public bool AddNewIngredient(){
            return true;
        }

        [HttpPost]
        [Route("UpdateIngredient")]
        public bool UpdateIngredient(){
            return true;
        }

        [HttpPost]
        [Route("DeleteIngredient")]
        public bool DeleteIngredient(){
            return true;
        }
    }
}