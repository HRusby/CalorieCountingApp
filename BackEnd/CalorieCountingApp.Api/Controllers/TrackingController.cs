using System;
using System.Collections.Generic;
using BackEnd.CalorieCountingApp.Api.Models;
using BackEnd.CalorieCountingApp.Domain;
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

        private readonly TrackingModel model;

        public TrackingController(IConfiguration configuration)
        {
            string connString = configuration.GetValue<string>("ConnectionStrings:CalorieCounting");
            model = new TrackingModel(connString);
        }

        [HttpPost]
        [Route("AddNewRecord")]
        public int AddNewRecord(TrackingRecord newRecord)
        {
            // TODO: Calculate the calories based on meal/ingredient id and quantity
            // Returns the new records Id
            if (newRecord.TypeId.Equals(TrackingTypeId.Individual))
            {
                return model.AddNewIndividualTrackingRecord(newRecord);
            }
            else if (newRecord.TypeId.Equals(TrackingTypeId.Meal))
            {
                return model.AddNewMealTrackingRecord(newRecord);
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
                return model.UpdateNewIndividualTrackingRecord(updatedRecord);
            }
            else if (updatedRecord.TypeId.Equals(TrackingTypeId.Meal))
            {
                return model.UpdateNewMealTrackingRecord(updatedRecord);
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
            return model.DeleteTrackingRecord(recordId);
        }

        [HttpPost]
        [Route("GetTrackingDataForDateAndUser")]
        public List<DisplayableTrackingRecord> GetTrackingDataForDateAndUser(TrackingDataRequest request)
        {
            return model.GetTrackingDataForDateAndUser(request);
        }
    }
}