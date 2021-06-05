CREATE PROCEDURE GetMeal(
    IN $MealId INTEGER
)
BEGIN
    SELECT 
        Id,
        Name,
        UserId,
        CookedWeight,
        CookedWeightMetricId,
        RemainingWeight,
        CookedOn
    FROM MEAL
    WHERE Id = $MealId;
END;