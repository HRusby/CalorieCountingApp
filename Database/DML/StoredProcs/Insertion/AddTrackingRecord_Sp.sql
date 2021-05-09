DELIMITER ,,

CREATE PROCEDURE AddTrackingRecord (
	IN $UserId INTEGER,
    IN $IngredientId INTEGER,
    IN $MetricId INTEGER,
    IN $Quantity DOUBLE,
    IN $DateTime DATETIME,
    OUT $GeneratedId INTEGER
)
BEGIN
	INSERT INTO TRACKING (
        UserId, 
        IngredientId, 
        MetricId, 
        Quantity, 
        `DateTime`)
    VALUES (
        $UserId,
        $IngredientId,
        $MetricId,
        $Quantity,
        $DateTime
    );

    SELECT LAST_INSERT_ID() INTO $GeneratedId; 
END;

,,