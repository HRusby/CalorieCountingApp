CREATE PROCEDURE GetAllUserTrackingRecords(
    IN $UserId INTEGER
)
BEGIN
    SELECT 
        Id,
        IngredientId,
        MetricId,
        Quantity,
        `DateTime`
    FROM TRACKING
    WHERE UserId = $UserId;
END;