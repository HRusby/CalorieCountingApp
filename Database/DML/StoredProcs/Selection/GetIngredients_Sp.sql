CREATE PROCEDURE GetIngredients()
BEGIN
    SELECT 
        Id,
        Name,
        CaloriesPerMetric,
        MetricId
    FROM INGREDIENT;
END;