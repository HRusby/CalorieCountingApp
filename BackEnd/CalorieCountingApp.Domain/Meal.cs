using System;
using CalorieCountingApp.Domain.Enums;

namespace CalorieCountingApp.Domain
{
    public class Meal
    {
        public int Id { get; private set; }
        public string Name { get; private set; }
        public int UserId { get; private set; }
        public double CookedWeight { get; private set; }
        public Metric CookedWeightMetricId { get; private set; }
        public double RemainingWeight { get; private set; }
        public DateTime CookedOn { get; private set; }

        public Meal(
            int id,
            string name,
            int userId,
            double cookedWeight,
            Metric cookedWeightMetricId,
            double remainingWeight,
            DateTime cookedOn)
        {
            Id = id;
            Name = name;
            UserId = userId;
            CookedWeight = cookedWeight;
            CookedWeightMetricId = cookedWeightMetricId;
            RemainingWeight = remainingWeight;
            CookedOn = cookedOn;
        }
    }
}