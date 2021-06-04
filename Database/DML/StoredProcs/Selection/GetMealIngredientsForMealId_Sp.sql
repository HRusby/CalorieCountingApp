CREATE PROCEDURE GetMealIngredientsForMealId(
    IN $MealId INTEGER
)
BEGIN
    SELECT 
	    mi.Id,
	    mi.MealId,
	    i.Name IngredientName,
	    m.ShortName MetricShortName,
	    mi.Quantity
	FROM MEAL_INGREDIENT mi
	INNER JOIN METRIC m ON mi.MetricId = m.Id
	INNER JOIN INGREDIENT i ON mi.IngredientId = i.Id 
	WHERE MealId = $MealId;
END;