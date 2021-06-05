CREATE OR REPLACE PROCEDURE UpdateMealIngredient (
    IN $MealIngredientId INTEGER,
    IN $IngredientId INTEGER,
    IN $Quantity DOUBLE
)
BEGIN
    -- Update Some Ingredient:
    -- MealId and Id should never change
    -- MealIngredientId and Quantity may change
	
    UPDATE MEAL_INGREDIENT SET
    IngredientId = IFNULL($IngredientId, IngredientId),
    Quantity = IFNULL($Quantity, Quantity)
    WHERE Id = $MealIngredientId;
END;