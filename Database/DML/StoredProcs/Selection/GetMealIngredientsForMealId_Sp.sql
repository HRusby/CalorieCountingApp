CREATE OR REPLACE PROCEDURE GetMealIngredientsForMealId(
    IN $MealId INTEGER
)
BEGIN
    SELECT 
	    mi.Id,
	    mi.MealId,
	    i.Name IngredientName,
	    mi.Quantity
	FROM MEAL_INGREDIENT mi
	INNER JOIN INGREDIENT i ON mi.IngredientId = i.Id 
	WHERE MealId = $MealId;
END;