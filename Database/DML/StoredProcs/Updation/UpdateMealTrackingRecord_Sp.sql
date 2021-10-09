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
   	DECLARE $quantityChange DOUBLE;
    SELECT TrackingId INTO $trackingId FROM MEAL_TRACKING WHERE Id = $MealTrackingId;

    CALL UpdateTrackingRecord($trackingId, $Quantity, $Calories, $DateTime);

	UPDATE MEAL_TRACKING SET
    MealId = IFNULL($MealOrIngredientId, MealId)
    WHERE Id = $MealTrackingId;
   	
    SELECT $Quantity - Quantity FROM TRACKING t WHERE Id = $trackingId;
   
    UPDATE MEAL SET RemainingWeight = RemainingWeight - $quantityChange
    WHERE Id = $MealOrIngredientId;
END;