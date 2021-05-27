CREATE PROCEDURE DeleteMealIngredient (
	IN $MealIngredientId INTEGER
)
BEGIN
	DELETE FROM MEAL_INGREDIENT
    WHERE Id = $MealIngredientId;
END;