DELIMITER ,,
CREATE PROCEDURE UpdateMealIngredient (
    IN $MealIngredientId INTEGER,
    IN $IngredientId INTEGER,
    IN $MetricId INTEGER,
    IN $Quantity DOUBLE,
    OUT GeneratedId INTEGER
)
BEGIN
    -- Update Some Ingredient:
    -- MealId and Id should never change
    -- MealIngredientId, MetricId and Quantity may change
	
    UPDATE MEAL_INGREDIENT SET
    IngredientId = IFNULL($IngredientId, IngredientId),
    MetricId = IFNULL($MetricId, MetricId),
    Quantity = IFNULL($Quantity, Quantity)
    WHERE Id = $MealIngredientId;
END;
,,