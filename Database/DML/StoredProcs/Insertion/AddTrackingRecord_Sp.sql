CREATE OR REPLACE PROCEDURE AddTrackingRecord (
	IN $UserId INTEGER,
    IN $TrackingTypeId INTEGER,
    IN $Quantity DOUBLE,
    IN $Calories DOUBLE,
    IN $DateTime DATETIME,
    OUT $GeneratedId INTEGER
)
BEGIN
	INSERT INTO TRACKING (
        UserId, 
        TrackingTypeId, 
        Quantity,
        Calories,
        `DateTime`)
    VALUES (
        $UserId,
        $TrackingTypeId,
        ROUND($Quantity, 2),
        ROUND($Calories, 2),
        $DateTime
    );

    SELECT LAST_INSERT_ID() INTO $GeneratedId; 
END;