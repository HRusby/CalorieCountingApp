using System;
using System.Collections.Generic;
using BackEnd.CalorieCountingApp.Domain;
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
        public int AddNewRecord(TrackingRecord newRecord)
        {
            // Returns the new records Id
            if (newRecord.TypeId.Equals(TrackingTypeId.Individual))
            {
                return dao.AddNewIndividualTrackingRecord(newRecord);
            }
            else if (newRecord.TypeId.Equals(TrackingTypeId.Meal))
            {
                return dao.AddNewMealTrackingRecord(newRecord);
            }
            else
            {
                throw new ArgumentOutOfRangeException("Tracking Type doesn't resolve to Individual or Meal for record: " + newRecord.ToString());
            }
        }

        [HttpPost]
        [Route("UpdateRecord")]
        public bool UpdateRecord(TrackingRecord updatedRecord)
        {
            if (updatedRecord.TypeId.Equals(TrackingTypeId.Individual))
            {
                return dao.UpdateNewIndividualTrackingRecord(updatedRecord);
            }
            else if (updatedRecord.TypeId.Equals(TrackingTypeId.Meal))
            {
                return dao.UpdateNewMealTrackingRecord(updatedRecord);
            }
            else
            {
                throw new ArgumentOutOfRangeException("Tracking Type doesn't resolve to Individual or Meal for record: " + updatedRecord.ToString());
            }
        }

        [HttpPost]
        [Route("DeleteRecord")]
        public bool DeleteRecord([FromBody] int recordId)
        {
            return dao.DeleteTrackingRecord(recordId);
        }

        [HttpPost]
        [Route("GetTrackingDataForDateAndUser")]
        public List<DisplayableTrackingRecord> GetTrackingDataForDateAndUser(TrackingDataRequest request)
        {
            return dao.GetTrackingDataForDateAndUser(request);
        }
    }
}