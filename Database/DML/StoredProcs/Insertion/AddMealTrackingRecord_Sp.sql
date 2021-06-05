CREATE PROCEDURE AddMealTrackingRecord (
	IN $UserId INTEGER,
    IN $Quantity DOUBLE,
    IN $Calories DOUBLE,
    IN $DateTime DATETIME,
    IN $MealId INTEGER,
    OUT $GeneratedId INTEGER
)
BEGIN
    DECLARE $typeId INTEGER;

    SELECT Id INTO $typeId FROM TRACKING_TYPE WHERE Type='Meal';

    CALL AddTrackingRecord($UserId, $typeId, $Quantity, $Calories, $DateTime, @trackingId);

	INSERT INTO MEAL_TRACKING (
        TrackingId, 
        MealId)
    VALUES (
        @trackingId,
        $MealId
    );

    SELECT LAST_INSERT_ID() INTO $GeneratedId; 
END;