CREATE OR REPLACE PROCEDURE AddIndividualTrackingRecord (
	IN $UserId INTEGER,
    IN $Quantity DOUBLE,
    IN $Calories DOUBLE,
    IN $DateTime DATETIME,
    IN $MealOrIngredientId INTEGER,
    OUT $GeneratedId INTEGER
)
BEGIN
    DECLARE $typeId INTEGER;

    SELECT Id INTO $typeId FROM TRACKING_TYPE WHERE Type='Individual';

    CALL AddTrackingRecord($UserId, $typeId, $Quantity, $Calories, $DateTime, @trackingId);

	INSERT INTO INDIVIDUAL_TRACKING (
        TrackingId, 
        IngredientId)
    VALUES (
        @trackingId,
        $MealOrIngredientId
    );

    SELECT LAST_INSERT_ID() INTO $GeneratedId; 
END;