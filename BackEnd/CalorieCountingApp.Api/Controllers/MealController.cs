using Microsoft.AspNetCore.Mvc;

namespace BackEnd.Controllers
{
    [ApiController]
    [Route("Meal")]
    public class MealController
    {
        [HttpPost]
        [Route("AddNewMeal")]
        public bool AddNewMeal(){
            return true;
        }

        [HttpPost]
        [Route("UpdateMeal")]
        public bool UpdateMeal(){
            return true;
        }

        [HttpPost]
        [Route("DeleteMeal")]
        public bool DeleteMeal(){
            return true;
        }
    }
}