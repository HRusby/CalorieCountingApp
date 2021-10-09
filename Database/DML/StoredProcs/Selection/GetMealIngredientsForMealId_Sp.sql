CREATE OR REPLACE PROCEDURE GetMealIngredientsForMealId(
    IN $MealId INTEGER
)
BEGIN
    SELECT 
	    mi.Id,
	    mi.MealId,
	    i.Name IngredientName,
	    mi.Quantity,
		m.ShortName MetricShortName
	FROM MEAL_INGREDIENT mi
	INNER JOIN INGREDIENT i ON mi.IngredientId = i.Id 
	INNER JOIN METRIC m ON i.MetricId = m.id
	WHERE MealId = $MealId;
END;