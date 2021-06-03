using CalorieCountingApp.Domain.Enums;

namespace CalorieCountingApp.Domain
{
    public class MealIngredient
    {
        public int Id { get; private set; }
        public int MealId { get; private set; }
        public int IngredientId { get; private set; }
        public MetricId MetricId { get; private set; }
        public double Quantity { get; private set; }

        public MealIngredient(
            int id,
            int ingredientId,
            double quantity,
            MetricId metricId,
            int mealId)
        {
            Id = id;
            IngredientId = ingredientId;
            Quantity = quantity;
            MetricId = metricId;
            MealId = mealId;
        }
    }
}