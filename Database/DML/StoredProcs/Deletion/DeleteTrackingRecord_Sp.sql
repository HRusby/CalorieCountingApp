DELIMITER ,,

CREATE PROCEDURE DeleteTrackingRecord (
	IN $TrackingId INTEGER
)
BEGIN
	DELETE FROM TRACKING 
    WHERE Id = $TrackingId;
END;
,,