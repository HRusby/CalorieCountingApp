CREATE PROCEDURE GetMealsForUser(
    IN $UserId INTEGER
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
    WHERE UserId = $UserId;
END;