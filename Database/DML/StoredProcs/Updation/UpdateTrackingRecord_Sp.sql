CREATE OR REPLACE PROCEDURE UpdateTrackingRecord (
    IN $TrackingId INT,
    IN $Quantity DOUBLE,
    IN $Calories DOUBLE,
    IN $DateTime DATETIME
)
BEGIN
	UPDATE TRACKING SET
    Quantity = IFNULL($Quantity, Quantity),
    Calories = IFNULL($Calories, Calories),
    `DateTime` = IFNULL($DateTime, `DateTime`)
    WHERE Id = $TrackingId;
END;