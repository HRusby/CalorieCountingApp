CREATE PROCEDURE UpdateMealIngredient (
    IN $IngredientId INTEGER,
    IN $FoodId INTEGER,
    IN $MetricId INTEGER,
    IN $Quantity DOUBLE,
    OUT GeneratedId INTEGER
)
BEGIN
    -- Update Some Ingredient:
    -- MealId and Id should never change
    -- FoodId, MetricId and Quantity may change
	
    UPDATE MEAL_INGREDIENT SET
    FoodId = IFNULL($FoodId, FoodId),
    MetricId = IFNULL($MetricId, MetricId),
    Quantity = IFNULL($Quantity, Quantity)
    WHERE Id = $IngredientId;
END;