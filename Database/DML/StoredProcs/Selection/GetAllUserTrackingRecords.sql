CREATE PROCEDURE GetAllUserTrackingRecords(
    IN $UserId INTEGER
)
BEGIN
    SELECT 
        Id,
        FoodId,
        MetricId,
        Quantity,
        `DateTime`
    FROM TRACKING
    WHERE UserId = $UserId
END;