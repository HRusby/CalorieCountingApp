CREATE PROCEDURE UpdateMeal (
    IN $MealId INTEGER,
    IN $Name VARCHAR(255),
    IN $CookedWeight VARCHAR(255),
    IN $CookedWeightMetricId VARCHAR(255),
    IN $RemainingWeight DOUBLE,
    IN $CookedOn DATETIME
)
BEGIN
    -- Update Some Meal, UserId, Id and CookedOn should never change
    -- CookedWeight and CookedWeightMetricId are expected to be set once then never changed
    -- But may be initially null.
	
    UPDATE MEAL SET
    Name = IFNULL($Name, Name),
    CookedWeight = IFNULL($CookedWeight, CookedWeight),
    CookedWeightMetricId = IFNULL($CookedWeightMetricId, CookedWeightMetricId),
    RemainingWeight = IFNULL($RemainingWeight, RemainingWeight),
    CookedOn = IFNULL($CookedOn, CookedOn)
    WHERE Id = $MealId;
END;