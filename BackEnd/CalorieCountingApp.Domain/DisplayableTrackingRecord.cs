using System;
using CalorieCountingApp.Domain.Enums;

namespace CalorieCountingApp.Domain
{
    public class DisplayableTrackingRecord : TrackingRecord
    {
        public string MetricShortName { get; private set; }
        public string MealOrIngredientName { get; private set; }

        public DisplayableTrackingRecord(
            int id,
            int mealOrIngredientId,
            int userId,
            TrackingTypeId trackingType,
            double quantity,
            decimal? calories,
            DateTime dateTime,
            string mealOrIngredientName,
            string metricShortName)
            : base(id,
                    mealOrIngredientId,
                    userId,
                    trackingType,
                    quantity,
                    calories,
                    dateTime)
        {
            MealOrIngredientName = mealOrIngredientName;
            MetricShortName = metricShortName;
        }
    }
}