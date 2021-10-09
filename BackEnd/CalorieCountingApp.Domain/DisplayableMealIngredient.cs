namespace CalorieCountingApp.Domain
{
    public class DisplayableMealIngredient
    {
        public int Id { get; private set; }
        public int MealId { get; private set; }
        public string IngredientName { get; private set; }
        public double Quantity { get; private set; }

        public string MetricShortName { get; private set; }

        public DisplayableMealIngredient(
            int id,
            int mealId,
            string ingredientName,
            double quantity,
            string metricShortName)
        {
            Id = id;
            MealId = mealId;
            IngredientName = ingredientName;
            Quantity = quantity;
            MetricShortName = metricShortName;
        }
    }
}