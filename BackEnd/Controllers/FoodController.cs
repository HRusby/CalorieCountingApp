using Microsoft.AspNetCore.Mvc;

namespace BackEnd.Controllers
{
    [ApiController]
    [Route("Meal")]
    public class FoodController
    {
        [HttpPost]
        [Route("AddNewFood")]
        public bool AddNewFood(){
            return true;
        }

        [HttpPost]
        [Route("UpdateFood")]
        public bool UpdateFood(){
            return true;
        }

        [HttpPost]
        [Route("DeleteFood")]
        public bool DeleteFood(){
            return true;
        }
    }
}