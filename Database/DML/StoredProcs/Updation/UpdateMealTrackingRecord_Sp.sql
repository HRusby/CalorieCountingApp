CREATE OR REPLACE PROCEDURE UpdateMealTrackingRecord (
    IN $MealTrackingId INTEGER,
    IN $TrackingTypeId INTEGER,
    IN $Quantity DOUBLE,
    IN $Calories DOUBLE,
    IN $DateTime DATETIME,
    IN $MealOrIngredientId INTEGER
)
BEGIN
    DECLARE $trackingId INTEGER;
    SELECT TrackingId INTO $trackingId FROM MEAL_TRACKING WHERE Id = $MealTrackingId;

    CALL UpdateTrackingRecord($trackingId, $Quantity, $Calories, $DateTime);

	UPDATE MEAL_TRACKING SET
    MealId = IFNULL($MealOrIngredientId, MealId)
    WHERE Id = $MealTrackingId;
END;