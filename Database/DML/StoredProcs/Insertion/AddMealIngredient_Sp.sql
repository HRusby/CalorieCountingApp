DELIMITER ,,

CREATE PROCEDURE AddMealIngredient (
    IN $MealId INTEGER,
    IN $IngredientId INTEGER,
    IN $MetricId INTEGER,
    IN $Quantity DOUBLE,
    OUT $GeneratedId INTEGER
)
BEGIN
    -- Adds a new Component of some Meal
    -- Gives the weight in the meal of this ingredient
	INSERT INTO MEAL_INGREDIENT (
        MealId, 
        IngredientId, 
        MetricId,
        Quantity
    )
    VALUES 
    (
        $MealId,
        $IngredientId,
        $MetricId,
        $Quantity
    );

    SELECT LAST_INSERT_ID() INTO $GeneratedId; 
END;

,,