using System;
using CalorieCountingApp.Data.Dao;
using CalorieCountingApp.Domain;
using CalorieCountingApp.Domain.Enums;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace CalorieCountingApp.Controllers
{
    [ApiController]
    [Route("Tracking")]
    public class TrackingController
    {

        private readonly TrackingDao dao;

        public TrackingController(IConfiguration configuration)
        {
            string connString = configuration.GetValue<string>("ConnectionStrings:CalorieCounting");
            dao = new TrackingDao(connString);
        }

        [HttpPost]
        [Route("AddNewRecord")]
        public int AddNewRecord(
            int userId,
            int ingredientId,
            MetricId metricId,
            double quantity,
            DateTime dateTime)
        {
            // Returns the new records Id
            return dao.AddNewTrackingRecord(
                        userId,
                        ingredientId,
                        metricId,
                        quantity,
                        dateTime);
        }

        [HttpPost]
        [Route("UpdateRecord")]
        public bool UpdateRecord(TrackingRecord updatedRecord){
            return dao.UpdateTrackingRecord(updatedRecord);
        }

        [HttpPost]
        [Route("DeleteRecord")]
        public bool DeleteRecord(int recordId){
            return dao.DeleteTrackingRecord(recordId);
        }
    }
}