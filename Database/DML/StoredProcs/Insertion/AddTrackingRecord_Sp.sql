CREATE PROCEDURE `AddTrackingRecord` (
	IN $UserId INTEGER,
    IN $FoodId INTEGER,
    IN $MetricId INTEGER,
    IN $Quantity DOUBLE,
    IN $DateTime DATETIME,
    OUT $GeneratedId INTEGER
)
BEGIN
	INSERT INTO TRACKING (
        UserId, 
        FoodId, 
        MetricId, 
        Quantity, 
        `DateTime`)
    VALUES (
        $UserId,
        $FoodId,
        $MetricId,
        $Quantity,
        $DateTime
    );

    SELECT LAST_INSERT_ID() INTO $GeneratedId; 
END;