using System;
using CalorieCountingApp.Domain.Enums;

namespace CalorieCountingApp.Domain
{
    public class TrackingRecord
    {
        public int Id { get; private set; }
        public int UserId { get; private set; }
        public int IngredientId { get; private set; }
        public MetricId MetricId { get; private set; }
        public double Quantity { get; private set; }
        public DateTime DateTime { get; private set; }

        public TrackingRecord(
            int id,
            int ingredientId, 
            double quantity, 
            int userId, 
            MetricId metricId, 
            DateTime dateTime)
        {
            Id = id;
            UserId = userId;
            IngredientId = ingredientId;
            MetricId = metricId;
            Quantity = quantity;        
            DateTime = dateTime;
        }
    }
}