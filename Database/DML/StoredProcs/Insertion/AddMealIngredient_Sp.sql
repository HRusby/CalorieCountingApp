CREATE OR REPLACE PROCEDURE AddMealIngredient (
    IN $MealId INTEGER,
    IN $IngredientId INTEGER,
    IN $Quantity DOUBLE,
    OUT $GeneratedId INTEGER
)
BEGIN
    -- Adds a new Component of some Meal
    -- Gives the weight in the meal of this ingredient
	INSERT INTO MEAL_INGREDIENT (
        MealId, 
        IngredientId, 
        Quantity
    )
    VALUES 
    (
        $MealId,
        $IngredientId,
        $Quantity
    );

    SELECT LAST_INSERT_ID() INTO $GeneratedId; 
END;