using Microsoft.AspNetCore.Mvc;

namespace BackEnd.Controllers
{
    [ApiController]
    [Route("Tracking")]
    public class TrackingController
    {
        [HttpPost]
        [Route("AddNewRecord")]
        public bool AddNewRecord(){
            return true;
        }

        [HttpPost]
        [Route("UpdateRecord")]
        public bool UpdateRecord(){
            return true;
        }

        [HttpPost]
        [Route("DeleteRecord")]
        public bool DeleteRecord(){
            return true;
        }
    }
}