CREATE PROCEDURE GetMealIngredientsForMealId(
    IN $MealId INTEGER
)
BEGIN
    SELECT 
        Id,
        MealId,
        IngredientId,
        MetricId,
        Quantity
    FROM MEAL_INGREDIENT
    WHERE MealId = $MealId;
END;