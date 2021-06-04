using CalorieCountingApp.Domain.Enums;

namespace CalorieCountingApp.Domain
{
    public class MealIngredient
    {
        public int? Id { get; private set; }
        public int MealId { get; private set; }
        public int IngredientId { get; private set; }
        public MetricId MetricId { get; private set; }
        public double Quantity { get; private set; }

        public MealIngredient(
            int? id,
            int mealId,
            int ingredientId,            
            MetricId metricId,            
            double quantity)
        {
            Id = id;
            MealId = mealId;
            IngredientId = ingredientId;
            MetricId = metricId;            
            Quantity = quantity;            
        }
    }
}