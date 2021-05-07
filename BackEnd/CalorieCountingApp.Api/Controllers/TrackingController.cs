using System;
using CalorieCountingApp.Domain;
using CalorieCountingApp.Domain.Enums;
using Microsoft.AspNetCore.Mvc;

namespace CalorieCountingApp.Controllers
{
    [ApiController]
    [Route("Tracking")]
    public class TrackingController
    {
        [HttpPost]
        [Route("AddNewRecord")]
        public int AddNewRecord(
            int userId,
            int ingredientId,
            Metric metricId,
            double quantity,
            DateTime dateTime)
        {
            // Returns the new records Id
            return -1;
        }

        [HttpPost]
        [Route("UpdateRecord")]
        public bool UpdateRecord(TrackingRecord updatedRecord){
            return true;
        }

        [HttpPost]
        [Route("DeleteRecord")]
        public bool DeleteRecord(int recordId){
            return true;
        }
    }
}