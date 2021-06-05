namespace CalorieCountingApp.Domain
{
    public class MealIngredient
    {
        public int? Id { get; private set; }
        public int MealId { get; private set; }
        public int IngredientId { get; private set; }
        public double Quantity { get; private set; }

        public MealIngredient(
            int? id,
            int mealId,
            int ingredientId,
            double quantity)
        {
            Id = id;
            MealId = mealId;
            IngredientId = ingredientId;      
            Quantity = quantity;            
        }
    }
}