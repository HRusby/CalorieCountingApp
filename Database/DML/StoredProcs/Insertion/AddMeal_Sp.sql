CREATE PROCEDURE AddMeal (
    IN $Name VARCHAR(255),
    IN $UserId VARCHAR(255),
    IN $CookedWeight VARCHAR(255),
    IN $CookedWeightMetricId VARCHAR(255),
    IN $CookedOn DATETIME,
    OUT $GeneratedId INTEGER
)
BEGIN
    -- Create a new Meal, CookedWeight can be null to start (i.e. until it's been cooked)
    -- If not null it is the same as Remaining Weight
	INSERT INTO MEAL (
        Name, 
        UserId, 
        CookedWeight,
        CookedWeightMetricId,
        RemainingWeight,
        CookedOn
    )
    VALUES 
    (
        $Name,
        $UserId,
        $CookedWeight,
        $CookedWeightMetricId,
        $CookedWeight,
        IFNULL($CookedOn, SYSDATE())
    );

    SELECT LAST_INSERT_ID() INTO $GeneratedId; 
END;