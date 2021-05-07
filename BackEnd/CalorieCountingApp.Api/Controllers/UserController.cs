using Microsoft.AspNetCore.Mvc;

namespace CalorieCountingApp.Controllers
{
    [ApiController]
    [Route("User")]
    public class UserController
    {
        [HttpPost]
        [Route("Login")]
        public bool Login(string userName, string password)
        {
            return true;
        }
    }
}