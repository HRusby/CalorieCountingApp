using System;
using CalorieCountingApp.Domain.Enums;

namespace CalorieCountingApp.Domain
{
    public class DisplayableTrackingRecord : TrackingRecord
    {
        public string IngredientName { get; private set; }
        public string MetricShortName { get; private set; }

        public DisplayableTrackingRecord(
            int id,
            int userId,
            int ingredientId, 
            MetricId metricId, 
            double quantity,            
            DateTime dateTime,
            string ingredientName,
            string metricShortName)
            : base(id, userId, ingredientId, metricId, quantity, dateTime)
        {
            IngredientName = ingredientName;
            MetricShortName = metricShortName;
        }
    }
}