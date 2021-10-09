CREATE OR REPLACE PROCEDURE UpdateTrackingRecord (
    IN $TrackingId INT,
    IN $Quantity DOUBLE,
    IN $Calories DOUBLE,
    IN $DateTime DATETIME
)
BEGIN
	UPDATE TRACKING SET
    Quantity = ROUND(IFNULL($Quantity, Quantity), 2),
    Calories = ROUND(IFNULL($Calories, Calories), 2),
    `DateTime` = IFNULL($DateTime, `DateTime`)
    WHERE Id = $TrackingId;
END;