CREATE PROCEDURE GetIngredient(
    IN $IngredientId INTEGER
)
BEGIN
    SELECT 
        Id,
        Name,
        CaloriesPerMetric,
        MetricId
    FROM INGREDIENT
    WHERE Id = $IngredientId;
END;