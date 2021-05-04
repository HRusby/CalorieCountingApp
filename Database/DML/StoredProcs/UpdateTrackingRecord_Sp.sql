CREATE PROCEDURE UpdateTrackingRecord (
    IN $TrackingId INTEGER,
    IN $UserId INTEGER,
    IN $FoodId INTEGER,
    IN $MetricId INTEGER,
    IN $Quantity DOUBLE,
    IN $DateTime DATETIME
)
BEGIN
	UPDATE TRACKING SET
    UserId = IFNULL($UserId, Name),
    FoodId = IFNULL($FoodId, Name),
    MetricId = IFNULL($MetricId, Name),
    Quantity = IFNULL($Quantity, Name),
    `DateTime` = IFNULL($DateTime, Name)
    WHERE Id = $TrackingId;
END;