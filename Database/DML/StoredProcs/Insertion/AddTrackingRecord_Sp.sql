CREATE PROCEDURE AddTrackingRecord (
	IN $UserId INTEGER,
    IN $TrackingTypeId INTEGER,
    IN $Quantity DOUBLE,
    IN $DateTime DATETIME,
    OUT $GeneratedId INTEGER
)
BEGIN
	INSERT INTO TRACKING (
        UserId, 
        TrackingTypeId, 
        Quantity,
        `DateTime`)
    VALUES (
        $UserId,
        $TrackingTypeId,
        $Quantity,
        $DateTime
    );

    SELECT LAST_INSERT_ID() INTO $GeneratedId; 
END;