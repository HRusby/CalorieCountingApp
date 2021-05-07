using Microsoft.AspNetCore.Mvc;

namespace CalorieCountingApp.Controllers
{
    [ApiController]
    [Route("User")]
    public class UserController
    {
        [HttpPost]
        [Route("Login")]
        public bool Login(string userName, string encodedPassword)
        {
            return true;
        }

        [HttpPost]
        [Route("AddNewUser")]
        public int AddNewUser(string userName, string encodedPassword)
        {
            // Returns the new user Id
            return -1;
        }
    }
}