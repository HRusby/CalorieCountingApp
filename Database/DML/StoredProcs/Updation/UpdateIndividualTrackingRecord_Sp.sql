CREATE OR REPLACE PROCEDURE UpdateIndividualTrackingRecord (
    IN $IndividualTrackingId INTEGER,
    IN $Quantity DOUBLE,
    IN $Calories DOUBLE,
    IN $DateTime DATETIME,
    IN $MealOrIngredientId INTEGER
)
BEGIN
    DECLARE $trackingId INTEGER;
    SELECT TrackingId INTO $trackingId 
    FROM INDIVIDUAL_TRACKING 
    WHERE Id = $IndividualTrackingId;

    CALL UpdateTrackingRecord($trackingId, $Quantity, $Calories, $DateTime);

	UPDATE INDIVIDUAL_TRACKING SET
    IngredientId = IFNULL($MealOrIngredientId, IngredientId)
    WHERE Id = $IndividualTrackingId;
END;