CREATE OR REPLACE PROCEDURE AddMealTrackingRecord (
	IN $UserId INTEGER,
    IN $Quantity DOUBLE,
    IN $Calories DOUBLE,
    IN $DateTime DATETIME,
    IN $MealOrIngredientId INTEGER,
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
        $MealOrIngredientId
    );

    SELECT LAST_INSERT_ID() INTO $GeneratedId; 
    
    UPDATE MEAL SET RemainingWeight = RemainingWeight - $Quantity
    WHERE Id = $MealOrIngredientId;
END;