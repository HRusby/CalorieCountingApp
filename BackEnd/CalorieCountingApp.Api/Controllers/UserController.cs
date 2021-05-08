using CalorieCountingApp.Data.Dao;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace CalorieCountingApp.Controllers
{
    [ApiController]
    [Route("User")]
    public class UserController
    {

        private readonly UserDao dao;

        public UserController(IConfiguration configuration)
        {
            string connString = configuration.GetValue<string>("ConnectionStrings:CalorieCounting");
            dao = new UserDao(connString);
        }

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