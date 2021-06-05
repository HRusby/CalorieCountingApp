CREATE PROCEDURE AddTrackingRecord (
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
        $Quantity,
        $Calories,
        $DateTime
    );

    SELECT LAST_INSERT_ID() INTO $GeneratedId; 
END;