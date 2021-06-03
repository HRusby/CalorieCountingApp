using System;
using CalorieCountingApp.Domain.Enums;

namespace CalorieCountingApp.Domain
{
    public class Ingredient
    {
        public int Id {get;private set;}
        public string Name {get; private set;}
        public decimal CaloriesPerMetric{get; private set;}
        public MetricId MetricId {get; private set;}

        public Ingredient(int id, 
            string name, 
            decimal caloriesPerMetric, 
            MetricId metricId)
        {
            Id = id;
            Name = name;
            CaloriesPerMetric = caloriesPerMetric;
            MetricId = metricId;
        }
    }
}
